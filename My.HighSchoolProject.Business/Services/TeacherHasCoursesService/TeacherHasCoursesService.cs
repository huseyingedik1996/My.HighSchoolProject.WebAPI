using AutoMapper;
using Common.My.HighSchoolProject.WebAPI.Response;
using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.TeacherHasCoursesDtos;
using FluentValidation;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.DataAccess.Models2;
using My.HighSchoolProject.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.Services.TeacherHasCoursesService
{
    public class TeacherHasCoursesService : ITeacherHasCoursesService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<CreateTeacherHasCoursesDto> _createValidator;
        private readonly IValidator <UpdateTeacherHasCoursesDto > _updateValidator;

        public TeacherHasCoursesService(IMapper mapper, IUow uow, IValidator<CreateTeacherHasCoursesDto> createValidator, IValidator<UpdateTeacherHasCoursesDto> updateValidator)
        {
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<CreateTeacherHasCoursesDto>> Create(CreateTeacherHasCoursesDto createTeacherCourse)
        {
            var validationResult = _createValidator.Validate(createTeacherCourse);
            if (validationResult.IsValid)
            {
                
                await _uow.GetRepository<TeachersHasCourse>().Create(_mapper.Map<TeachersHasCourse>(createTeacherCourse));
                await _uow.SaveChanges();
                return new ResponseT<CreateTeacherHasCoursesDto>(ResponseType.Success, createTeacherCourse);
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
                return new ResponseT<CreateTeacherHasCoursesDto>(ResponseType.ValidationError, createTeacherCourse, errors);
            }
        }

        public async Task<IResponse<List<ListTeacherHasCoursesDto>>> GetAll()
        {
            var data = _mapper.Map<List<ListTeacherHasCoursesDto>>(await _uow.GetRepository<TeachersHasCourse>().GetAll());
            return new ResponseT<List<ListTeacherHasCoursesDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<ListTeacherHasCoursesDto>> GetById(int id)
        {
            var data = _mapper.Map<ListTeacherHasCoursesDto>(await _uow.GetRepository<TeachersHasCourse>().GetByFilter(x => x.IdTeacherhasCourses == id));
            return new ResponseT<ListTeacherHasCoursesDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepository<TeachersHasCourse>().GetByFilter(x => x.IdTeacherhasCourses == id);
            if (removedEntry != null)
            {
                _uow.GetRepository<TeachersHasCourse>().Remove(removedEntry);
                await _uow.SaveChanges();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<List<UpdateTeacherHasCoursesDto>>> UpdateDtos(UpdateTeacherHasCoursesDto updateTeacherCourse)
        {
            var validationResult = _updateValidator.Validate(updateTeacherCourse);
            if (!validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();
                return new ResponseT<List<UpdateTeacherHasCoursesDto>>(ResponseType.NotFound, "Teachers courses not found.");
            }

            var updatedEntity = await _uow.GetRepository<UpdateTeacherHasCoursesDto>().GetById(updateTeacherCourse.IdTeacherhasCourses);
            if (updatedEntity != null)
            {
                _uow.GetRepository<UpdateTeacherHasCoursesDto>().Update(_mapper.Map<UpdateTeacherHasCoursesDto>(updateTeacherCourse), updatedEntity);
                await _uow.SaveChanges();
                return new ResponseT<List<UpdateTeacherHasCoursesDto>>(ResponseType.Success, "Teachers courses updated successfully.");
            }
            else
            {
                return new ResponseT<List<UpdateTeacherHasCoursesDto>>(ResponseType.NotFound, "Teachers courses not found.");
            }
        }
    }
}
