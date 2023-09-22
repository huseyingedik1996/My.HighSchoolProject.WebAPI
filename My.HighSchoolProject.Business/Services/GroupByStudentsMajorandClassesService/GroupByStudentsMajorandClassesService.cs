using AutoMapper;
using Common.My.HighSchoolProject.WebAPI.Response;
using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.GroupByStudentsMajorAndClass;
using DTO.My.HighSchoolProject.WebAPI.Dto.MajorDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentClassMajorsDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentDtos;
using FluentValidation;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.DataAccess.BaseEntities;
using My.HighSchoolProject.DataAccess.Models;
using My.HighSchoolProject.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http.HttpResults;

namespace My.HighSchoolProject.Business.Services.GroupByStundentsMajorAndClassesService
{
    public class GroupByStudentsMajorandClassesService : IGroupByStundentsMajorAndClasses
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateGroupByStudentsMajorAndClass> _validatorCreateGroupSmC;
        private readonly IValidator<UpdateGroupByStudentsMajorAndClass> _validatorUpdateGroupSmC;
        private readonly IdoListGroupByStudentsMajorAndClass _createGroupList;

        public GroupByStudentsMajorandClassesService(IUow uow, IMapper mapper, IValidator<CreateGroupByStudentsMajorAndClass> validatorCreateGroupSmC, IValidator<UpdateGroupByStudentsMajorAndClass> validatorUpdateGroupSmC, IdoListGroupByStudentsMajorAndClass createGroupList)
        {
            _uow = uow;
            _mapper = mapper;
            _validatorCreateGroupSmC = validatorCreateGroupSmC;
            _validatorUpdateGroupSmC = validatorUpdateGroupSmC;
            _createGroupList = createGroupList;
        }
        //Dependency ile ListStudentClassAndMajor, liste uzunluğu ve group kapasite ile while döngüsü? her döngü de group kapasite +1
        //while öncesi group kapasite belirlenmeli ancak veriler database e gönderilmemeli 
        //öğrenciler nasıl bir sıralama da eklenecek? 
        //GetAll ile grouplar studentNumber - name - surname ile verilmeli (inner join)
        //GetById de kıstas groupCode olabilir?
        public async Task<IResponse<CreateGroupByStudentsMajorAndClass>> Create(CreateGroupByStudentsMajorAndClass createGroupSmc)
        {
            var validationResult = _validatorCreateGroupSmC.Validate(createGroupSmc);
            if (validationResult.IsValid)
            {                               
                var classAndMajorsData = _mapper.Map<List<ListStudentMajorClassesDto>>(await _uow.GetRepository<Studentmajorclass>().GetAll()).ToList();
                var groupCapacity = createGroupSmc.GroupCapacity;
                var setCapacity = groupCapacity;
                int getCount = 0;
                object tryin = null;
                
                foreach(var id in classAndMajorsData)
                {
                    _createGroupList.IdStudentMajorClasses = id.IdStudentMajorClasses;
                    setCapacity--;
                    getCount++;
                    tryin = $"{groupCapacity}/{getCount}";
                    
                    if (getCount == groupCapacity)
                    {
                        break;
                    }
                }
                _createGroupList.IdMajorClassGroups = createGroupSmc.IdMajorClassGroups;
                _createGroupList.GroupCapacity = getCount;

                await _uow.GetRepository<Groupbystudentsmajorandclass>().Create(_mapper.Map<Groupbystudentsmajorandclass>(_createGroupList));
                
                await _uow.SaveChanges();
                return new ResponseT<CreateGroupByStudentsMajorAndClass>(ResponseType.Success, createGroupSmc);
            }
            else
            {
                List<CustomValidationError> errors = new();
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(new()
                    {
                        ErrorMessage = error.ErrorMessage,
                        PropertyName = error.PropertyName
                    });
                }
                return new ResponseT<CreateGroupByStudentsMajorAndClass>(ResponseType.ValidationError, createGroupSmc, errors);
            }

        }
       

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepository<Groupbystudentsmajorandclass>().GetByFilter(x => x.IdGroupByStudentsMajorAndClasses == id);
            return new ResponseT<bool>(ResponseType.Success, "successfull");
        }

        public async Task<List<UpdateGroupByStudentsMajorAndClass>> UpdateDtos(UpdateGroupByStudentsMajorAndClass updateGroupSmC)
        {
            var updatedEntity = await _uow.GetRepository<UpdateGroupByStudentsMajorAndClass>().GetById(updateGroupSmC.IdGroupByStudentsMajorAndClasses);
            if (updatedEntity != null)
            {
                _uow.GetRepository<UpdateGroupByStudentsMajorAndClass>().Update(_mapper.Map<UpdateGroupByStudentsMajorAndClass>(updatedEntity), updatedEntity);
                await _uow.SaveChanges();
                return new List<UpdateGroupByStudentsMajorAndClass> { updatedEntity };
            }
            else
            {
                return null;
            }
        }
    }
}
