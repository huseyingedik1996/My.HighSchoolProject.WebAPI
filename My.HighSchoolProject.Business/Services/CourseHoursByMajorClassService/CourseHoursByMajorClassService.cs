using AutoMapper;
using Common.My.HighSchoolProject.WebAPI.Response;
using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.CourseHoursByMajorClassDto;
using FluentValidation;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.DataAccess.Models;
using My.HighSchoolProject.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.Services.CourseHoursByMajorClassService
{
    public class CourseHoursByMajorClassService : ICourseHoursByMajorClassService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<CreateCourseHoursByMajorClassDto> _createValidator;
        private readonly IValidator<UpdateCourseHoursByMajorClassDto> _updateValidator;

        public CourseHoursByMajorClassService(IMapper mapper, IUow uow, IValidator<CreateCourseHoursByMajorClassDto> createValidator, IValidator<UpdateCourseHoursByMajorClassDto?> updateValidator)
        {
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<CreateCourseHoursByMajorClassDto>> Create(CreateCourseHoursByMajorClassDto createCoursehour)
        {
            var validationResult = _createValidator.Validate(createCoursehour);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Coursehoursbymajorclass>().Create(_mapper.Map<Coursehoursbymajorclass>(createCoursehour));
                await _uow.SaveChanges();
                return new ResponseT<CreateCourseHoursByMajorClassDto>(ResponseType.Success, createCoursehour);
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
                return new ResponseT<CreateCourseHoursByMajorClassDto>(ResponseType.ValidationError, createCoursehour, errors);
            }
        }

        public async Task<IResponse<List<ListCourseHoursByMajorClassDto>>> GetAll()
        {
            var data = _mapper.Map<List<ListCourseHoursByMajorClassDto>>(await _uow.GetRepository<Coursehoursbymajorclass>().GetAll());
            return new ResponseT<List<ListCourseHoursByMajorClassDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<ListCourseHoursByMajorClassDto>> GetById(int id)
        {
            var data = _mapper.Map<ListCourseHoursByMajorClassDto>(await _uow.GetRepository<Coursehoursbymajorclass>().GetByFilter(x => x.IdCourseHoursByMajorClasses == id));
            return new ResponseT<ListCourseHoursByMajorClassDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepository<Coursehoursbymajorclass>().GetByFilter(x => x.IdCourseHoursByMajorClasses == id);
            if (removedEntry != null)
            {
                _uow.GetRepository<Coursehoursbymajorclass>().Remove(removedEntry);
                await _uow.SaveChanges();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<List<UpdateCourseHoursByMajorClassDto>>> UpdateDtos(UpdateCourseHoursByMajorClassDto updateCoursehour)
        {
            var validationResult = _updateValidator.Validate(updateCoursehour);
            if (!validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();
                return new ResponseT<List<UpdateCourseHoursByMajorClassDto>>(ResponseType.NotFound, "Hour setup not found.");
            }

            var updatedEntity = await _uow.GetRepository<UpdateCourseHoursByMajorClassDto>().GetById(updateCoursehour.IdCourseHoursByMajorClasses);
            if (updatedEntity != null)
            {
                _uow.GetRepository<UpdateCourseHoursByMajorClassDto>().Update(_mapper.Map<UpdateCourseHoursByMajorClassDto>(updateCoursehour), updatedEntity);
                await _uow.SaveChanges();
                return new ResponseT<List<UpdateCourseHoursByMajorClassDto>>(ResponseType.Success, "Hour setup updated successfully.");
            }
            else
            {
                return new ResponseT<List<UpdateCourseHoursByMajorClassDto>>(ResponseType.NotFound, "Hour setup not found.");
            }
        }
    }
}
