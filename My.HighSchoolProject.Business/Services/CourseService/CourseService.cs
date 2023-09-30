using AutoMapper;
using Common.My.HighSchoolProject.WebAPI.Response;
using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.CourseDto;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.DataAccess.Models2;
using My.HighSchoolProject.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.Services.CourseService
{
    public class CourseService : ICourseService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<CreateCourseDto> _createValidator;
        private readonly IValidator<UpdateCourseDto> _updateValidator;

        public CourseService(IMapper mapper, IUow uow, IValidator<CreateCourseDto> createValidator, IValidator<UpdateCourseDto> updateValidator)
        {
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<CreateCourseDto>> Create(CreateCourseDto courseDto)
        {
            var validationResult = _createValidator.Validate(courseDto);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Course>().Create(_mapper.Map<Course>(courseDto));
                await _uow.SaveChanges();
                return new ResponseT<CreateCourseDto>(ResponseType.Success, courseDto);
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
                return new ResponseT<CreateCourseDto>(ResponseType.ValidationError, courseDto, errors);
            }
        }

        public async Task<IResponse<List<ListCourseDto>>> GetAll()
        {
            var data = _mapper.Map<List<ListCourseDto>>(await _uow.GetRepository<Course>().GetAll());
            return new ResponseT<List<ListCourseDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<ListCourseDto>> GetById(int id)
        {
            var data = _mapper.Map<ListCourseDto>(await _uow.GetRepository<Course>().GetByFilter(x => x.IdCourse == id));
            return new ResponseT<ListCourseDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepository<Course>().GetByFilter(x => x.IdCourse == id);
            if (removedEntry != null)
            {
                _uow.GetRepository<Course>().Remove(removedEntry);
                await _uow.SaveChanges();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<List<UpdateCourseDto>>> UpdateDtos(UpdateCourseDto updateCourseDto)
        {
            var validationResult = _updateValidator.Validate(updateCourseDto);
            if (!validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();
                return new ResponseT<List<UpdateCourseDto>>(ResponseType.NotFound, "Course not found.");
            }

            var updatedEntity = await _uow.GetRepository<UpdateCourseDto>().GetById(updateCourseDto.IdCourse);
            if (updatedEntity != null)
            {
                _uow.GetRepository<UpdateCourseDto>().Update(_mapper.Map<UpdateCourseDto>(updateCourseDto), updatedEntity);
                await _uow.SaveChanges();
                return new ResponseT<List<UpdateCourseDto>>(ResponseType.Success, "Course updated successfully.");
            }
            else
            {
                return new ResponseT<List<UpdateCourseDto>>(ResponseType.NotFound, "Course not found.");
            }
        }
    }
}
