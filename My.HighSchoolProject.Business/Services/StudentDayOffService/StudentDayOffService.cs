using AutoMapper;
using Common.My.HighSchoolProject.WebAPI.Response;
using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentDayOffDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentDtos;
using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using FluentValidation;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.DataAccess.BaseEntities;
using My.HighSchoolProject.DataAccess.Models;
using My.HighSchoolProject.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.Services.StudentDayOffService
{
    public class StudentDayOffService : IStudentDayOffService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<CreateStudentDayOffDto> _validatorCreate;
        private readonly IValidator<UpdateStudentDayOfDto> _validatorUpdate;
        private readonly IDtoStudentDayOffHasStudent _foreignTable;

        public StudentDayOffService(IMapper mapper, IUow uow, IValidator<CreateStudentDayOffDto> validatorCreate, IValidator<UpdateStudentDayOfDto> validatorUpdate, IDtoStudentDayOffHasStudent foreignTable)
        {
            _mapper = mapper;
            _uow = uow;
            _validatorCreate = validatorCreate;
            _validatorUpdate = validatorUpdate;
            _foreignTable = foreignTable;
        }

        public async Task<IResponse<CreateStudentDayOffDto>> Create(CreateStudentDayOffDto createDayOff)
        {
            var validationResult = _validatorCreate.Validate(createDayOff);
            if (validationResult.IsValid)
            {

                var newDayoff = _mapper.Map<Studentsdayoff>(createDayOff);
                await _uow.GetRepository<Studentsdayoff>().Create(newDayoff);
                await _uow.SaveChanges();
                return new ResponseT<CreateStudentDayOffDto>(ResponseType.Success, createDayOff);
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
                return new ResponseT<CreateStudentDayOffDto>(ResponseType.ValidationError, createDayOff, errors);
            }
        }

        public async Task<IResponse<List<ListStudentDayOffDto>>> GetAll()
        {
            var data = _mapper.Map<List<ListStudentDayOffDto>>(await _uow.GetRepository<Studentsdayoff>().GetAll());
            return new ResponseT<List<ListStudentDayOffDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<ListStudentDayOffDto>> GetById(int id)
        {
            var data = _mapper.Map<ListStudentDayOffDto>(await _uow.GetRepository<Studentsdayoff>().GetByFilter(x => x.IdStudentsDayoff == id));
            return new ResponseT<ListStudentDayOffDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepository<Studentsdayoff>().GetByFilter(x => x.IdStudentsDayoff == id);
            if (removedEntry != null)
            {
                _uow.GetRepository<Studentsdayoff>().Remove(removedEntry);
                await _uow.SaveChanges();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<List<UpdateStudentDayOfDto>>> UpdateDtos(UpdateStudentDayOfDto updateDayOff)
        {
            var validationResult = _validatorUpdate.Validate(updateDayOff);
            if (validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();

                return new ResponseT<List<UpdateStudentDayOfDto>>(ResponseType.NotFound, "not found.");
            }

            var updatedEntity = await _uow.GetRepository<UpdateStudentDayOfDto>().GetById(updateDayOff.IdStudentsDayoff);
            if (updatedEntity != null)
            {
                _uow.GetRepository<UpdateStudentDayOfDto>().Update(_mapper.Map<UpdateStudentDayOfDto>(updatedEntity), updatedEntity);
                await _uow.SaveChanges();
                return new ResponseT<List<UpdateStudentDayOfDto>>(ResponseType.Success, "Info updated successfully.");
            }
            else
            {
                return new ResponseT<List<UpdateStudentDayOfDto>>(ResponseType.NotFound, "Requested info can not be found.");
            }
        }
    }
}
