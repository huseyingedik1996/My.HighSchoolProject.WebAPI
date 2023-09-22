using AutoMapper;
using Common.My.HighSchoolProject.WebAPI.Response;
using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomsGroupDtos;
using FluentValidation;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.DataAccess.Models;
using My.HighSchoolProject.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.Services
{
    public class ClassroomsGroupService : IClassroomsGroupService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<CreateClassroomsGroupDto> _createValidator;
        private readonly IValidator<UpdateClassroomsGroupDto> _updateValidator;

        public ClassroomsGroupService(IMapper mapper, IUow uow, IValidator<CreateClassroomsGroupDto> createValidator, IValidator<UpdateClassroomsGroupDto> updateValidator)
        {
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<CreateClassroomsGroupDto>> Create(CreateClassroomsGroupDto createClassgroup)
        {
            var validationResult = _createValidator.Validate(createClassgroup);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Classroomsgroup>().Create(_mapper.Map<Classroomsgroup>(createClassgroup));
                await _uow.SaveChanges();
                return new ResponseT<CreateClassroomsGroupDto>(ResponseType.Success, createClassgroup);
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
                return new ResponseT<CreateClassroomsGroupDto>(ResponseType.ValidationError, createClassgroup, errors);
            }
        }

        public async Task<IResponse<List<ListClassroomsGroupDto>>> GetAll()
        {
            var data = _mapper.Map<List<ListClassroomsGroupDto>>(await _uow.GetRepository<Classroomsgroup>().GetAll());
            return new ResponseT<List<ListClassroomsGroupDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<ListClassroomsGroupDto>> GetById(int id)
        {
            var data = _mapper.Map<ListClassroomsGroupDto>(await _uow.GetRepository<Classroomsgroup>().GetByFilter(x => x.IdClassGroup == id));
            return new ResponseT<ListClassroomsGroupDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepository<Classroomsgroup>().GetByFilter(x => x.IdClassGroup == id);
            if (removedEntry != null)
            {
                _uow.GetRepository<Classroomsgroup>().Remove(removedEntry);
                await _uow.SaveChanges();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<List<UpdateClassroomsGroupDto>>> UpdateDtos(UpdateClassroomsGroupDto updateClassroomgroup)
        {
            var validationResult = _updateValidator.Validate(updateClassroomgroup);
            if (!validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();
                return new ResponseT<List<UpdateClassroomsGroupDto>>(ResponseType.NotFound, "Classroom group not found.");
            }

            var updatedEntity = await _uow.GetRepository<UpdateClassroomsGroupDto>().GetById(updateClassroomgroup.IdClassGroup);
            if (updatedEntity != null)
            {
                _uow.GetRepository<UpdateClassroomsGroupDto>().Update(_mapper.Map<UpdateClassroomsGroupDto>(updateClassroomgroup), updatedEntity);
                await _uow.SaveChanges();
                return new ResponseT<List<UpdateClassroomsGroupDto>>(ResponseType.Success, "Classroom group updated successfully.");
            }
            else
            {
                return new ResponseT<List<UpdateClassroomsGroupDto>>(ResponseType.NotFound, "Classroom group not found.");
            }
        }
    }
}
