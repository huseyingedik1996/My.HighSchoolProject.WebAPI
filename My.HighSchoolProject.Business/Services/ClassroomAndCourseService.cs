using AutoMapper;
using Common.My.HighSchoolProject.WebAPI.Response;
using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomAndCourseDto;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomsGroupDtos;
using FluentValidation;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.DataAccess.Models2;
using My.HighSchoolProject.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.Services
{
    public class ClassroomAndCourseService : IClassroomAndGroupService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<CreateClassroomAndCourseDto> _createValidator;
        private readonly IValidator<UpdateClassroomAndCourseDto> _updateValidator;
        private readonly HighSchoolDatabaseContext _context;

        public ClassroomAndCourseService(IMapper mapper, IUow uow, IValidator<CreateClassroomAndCourseDto> validatorCreate, IValidator<UpdateClassroomAndCourseDto> validatorUpdate, HighSchoolDatabaseContext context)
        {
            _mapper = mapper;
            _uow = uow;
            _createValidator = validatorCreate;
            _updateValidator = validatorUpdate;
            _context = context;
        }

        public async Task<IResponse<CreateClassroomAndCourseDto>> Create(CreateClassroomAndCourseDto createClassCourse)
        {
            var validationResult = _createValidator.Validate(createClassCourse);
           
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Classroomsandcourse>().Create(_mapper.Map<Classroomsandcourse>(createClassCourse));
                await _uow.SaveChanges();
                return new ResponseT<CreateClassroomAndCourseDto>(ResponseType.Success, createClassCourse);


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
                return new ResponseT<CreateClassroomAndCourseDto>(ResponseType.ValidationError, createClassCourse, errors);
            }
        }

        public async Task<IResponse<List<ListClassroomAndCourseDto>>> GetAll()
        {
            var data = _mapper.Map<List<ListClassroomAndCourseDto>>(await _uow.GetRepository<Classroomsandcourse>().GetAll());
            return new ResponseT<List<ListClassroomAndCourseDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<ListClassroomAndCourseDto>> GetById(int id)
        {
            var data = _mapper.Map<ListClassroomAndCourseDto>(await _uow.GetRepository<Classroomsandcourse>().GetByFilter(x => x.IdClassRoomsAndGroups == id));
            return new ResponseT<ListClassroomAndCourseDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepository<Classroomsandcourse>().GetByFilter(x => x.IdClassRoomsAndGroups == id);
            if (removedEntry != null)
            {
                _uow.GetRepository<Classroomsandcourse>().Remove(removedEntry);
                await _uow.SaveChanges();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<List<UpdateClassroomAndCourseDto>>> UpdateDtos(UpdateClassroomAndCourseDto updateClassCourse)
        {
            var validationResult = _updateValidator.Validate(updateClassCourse);
            if (!validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();
                return new ResponseT<List<UpdateClassroomAndCourseDto>>(ResponseType.NotFound, "Specific classroom not found.");
            }

            var updatedEntity = await _uow.GetRepository<UpdateClassroomAndCourseDto>().GetById(updateClassCourse.IdClassRoomsAndGroups);
            if (updatedEntity != null)
            {
                _uow.GetRepository<UpdateClassroomAndCourseDto>().Update(_mapper.Map<UpdateClassroomAndCourseDto>(updateClassCourse), updatedEntity);
                await _uow.SaveChanges();
                return new ResponseT<List<UpdateClassroomAndCourseDto>>(ResponseType.Success, "Specific classroom updated successfully.");
            }
            else
            {
                return new ResponseT<List<UpdateClassroomAndCourseDto>>(ResponseType.NotFound, "Specific classroom not found.");
            }
        }
    }
}
