using AutoMapper;
using Common.My.HighSchoolProject.WebAPI.Response;
using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomDtos;
using FluentValidation;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.DataAccess.Models2;
using My.HighSchoolProject.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.Services.ClassroomService
{
    public class ClassroomService : IClassroomService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<CreateClassroomDto> _validatorCreate;
        private readonly IValidator<UpdateClassroomDto> _validatorUpdate;

        public ClassroomService(IMapper mapper, IUow uow, IValidator<UpdateClassroomDto> validatorUpdate, IValidator<CreateClassroomDto> validatorCreate)
        {
            _mapper = mapper;
            _uow = uow;
            _validatorUpdate = validatorUpdate;
            _validatorCreate = validatorCreate;
        }

        public async Task<IResponse<CreateClassroomDto>> Create(CreateClassroomDto createClassroom)
        {
            var validationResult = _validatorCreate.Validate(createClassroom);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Classroom>().Create(_mapper.Map<Classroom>(createClassroom));
                await _uow.SaveChanges();
                return new ResponseT<CreateClassroomDto>(ResponseType.Success, createClassroom);
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
                return new ResponseT<CreateClassroomDto>(ResponseType.ValidationError, createClassroom, errors);
            }
        }

        public async Task<IResponse<List<ListClassroomDto>>> GetAll()
        {
            var data = _mapper.Map<List<ListClassroomDto>>(await _uow.GetRepository<Classroom>().GetAll());
            return new ResponseT<List<ListClassroomDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<ListClassroomDto>> GetById(int id)
        {
            var data = _mapper.Map<ListClassroomDto>(await _uow.GetRepository<Classroom>().GetByFilter(x => x.IdClassRooms == id));
            return new ResponseT<ListClassroomDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepository<Classroom>().GetByFilter(x => x.IdClassRooms == id);
            if (removedEntry != null)
            {
                _uow.GetRepository<Classroom>().Remove(removedEntry);
                await _uow.SaveChanges();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<List<UpdateClassroomDto>>> UpdateDtos(UpdateClassroomDto updateClassroom)
        {
            var validationResult = _validatorUpdate.Validate(updateClassroom);
            if (!validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();
                return new ResponseT<List<UpdateClassroomDto>>(ResponseType.NotFound, "Class not found.");
            }

            var updatedEntity = await _uow.GetRepository<UpdateClassroomDto>().GetById(updateClassroom.IdClassRooms);
            if (updatedEntity != null)
            {
                _uow.GetRepository<UpdateClassroomDto>().Update(_mapper.Map<UpdateClassroomDto>(updateClassroom), updatedEntity);
                await _uow.SaveChanges();
                return new ResponseT<List<UpdateClassroomDto>>(ResponseType.Success, "Class updated successfully.");
            }
            else
            {
                return new ResponseT<List<UpdateClassroomDto>>(ResponseType.NotFound, "Class not found.");
            }
        }
    }
}