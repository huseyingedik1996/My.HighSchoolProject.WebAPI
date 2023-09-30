using AutoMapper;
using Azure;
using Common.My.HighSchoolProject.WebAPI.Response;
using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.ContactDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentClassMajorsDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentDtos;
using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using FluentValidation;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.DataAccess.BaseEntities;
using My.HighSchoolProject.DataAccess.Models2;
using My.HighSchoolProject.DataAccess.UnitOfWork;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<StudentCreateDto> _studentCreateValidator;
        private readonly IValidator<StudentUpdateDto> _studentUpdateValidator;
        private readonly IValidator<CreateStudentMajorClassesDto> _createStudentMajorClassesValidator;
        private readonly IDtoStudentMajorClasses _createSmC;

        public StudentService(IMapper mapper, IUow uow, IValidator<StudentCreateDto> studentCreateValidator, IValidator<StudentUpdateDto> studentUpdateValidator, IValidator<CreateStudentMajorClassesDto> createStudentMajorClassesValidator, IDtoStudentMajorClasses createSmC)
        {
            _mapper = mapper;
            _uow = uow;
            _studentCreateValidator = studentCreateValidator;
            _studentUpdateValidator = studentUpdateValidator;
            _createStudentMajorClassesValidator = createStudentMajorClassesValidator;
            _createSmC = createSmC;
        }

        public async Task<IResponse<StudentCreateDto>> Create(StudentCreateDto studentCreateDto)
        {
            var validationResult = _studentCreateValidator.Validate(studentCreateDto);
            if (validationResult.IsValid)
            {
                var newStudent = _mapper.Map<Student>(studentCreateDto);
                await _uow.GetRepository<Student>().Create(newStudent);
                await _uow.SaveChanges();

                #region StudentmajorclassInfoCreate
                int createdId = newStudent.IdstudentNumber;
                _createSmC.IdstudentNumber = createdId;
                _createSmC.IdMajors = studentCreateDto.IdMajor;
                _createSmC.IdClasses = studentCreateDto.IdClass;
                #endregion

                var getKeys = _mapper.Map<Studentmajorclass>(_createSmC);
                await _uow.GetRepository<Studentmajorclass>().Create(getKeys);
                await _uow.SaveChanges();
                return new ResponseT<StudentCreateDto>(ResponseType.Success, studentCreateDto);
                
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
                return new ResponseT<StudentCreateDto>(ResponseType.ValidationError, studentCreateDto, errors);
            }
            
        }

        public async Task<IResponse<List<StudentListDtos>>> GetAll()
        {
            var data = _mapper.Map<List<StudentListDtos>>(await _uow.GetRepository<Student>().GetAll());
            return new ResponseT<List<StudentListDtos>>(ResponseType.Success, data);

        }


        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepository<Student>().GetByFilter(x => x.IdstudentNumber == id);
            if (removedEntry != null)
            {
                _uow.GetRepository<Student>().Remove(removedEntry);
                await _uow.SaveChanges();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }


        public async Task<IResponse<List<StudentUpdateDto>>> UpdateDtos(StudentUpdateDto studentUpdateDto)
        {
            var validationResult = _studentUpdateValidator.Validate(studentUpdateDto);
            if (!validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();
                return new ResponseT<List<StudentUpdateDto>>(ResponseType.NotFound, "Student not found.");
            }

            var updatedEntity = await _uow.GetRepository<StudentUpdateDto>().GetById(studentUpdateDto.IdstudentNumber);
            if (updatedEntity != null)
            {
                _uow.GetRepository<StudentUpdateDto>().Update(_mapper.Map<StudentUpdateDto>(studentUpdateDto), updatedEntity);
                await _uow.SaveChanges();
                return new ResponseT<List<StudentUpdateDto>>(ResponseType.Success, "Student updated successfully.");
            }
            else
            {
                return new ResponseT<List<StudentUpdateDto>>(ResponseType.NotFound, "Student not found.");
            }
        }

        public async Task<IResponse<StudentListDtos>> GetById(int id)
        {
            var data = _mapper.Map<StudentListDtos>(await _uow.GetRepository<Student>().GetByFilter(x => x.IdstudentNumber == id));
            return new ResponseT<StudentListDtos>(ResponseType.Success, data);
        }

    }
}
