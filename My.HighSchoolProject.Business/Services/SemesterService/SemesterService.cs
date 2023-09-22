using AutoMapper;
using Common.My.HighSchoolProject.WebAPI.Response;
using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.MajorDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.SemesterDtos;
using FluentValidation;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.DataAccess.Models;
using My.HighSchoolProject.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.Services.SemesterService
{
    public class SemesterService : ISemesterService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<SemesterUpdateDto> _updateValidator;
        private readonly IValidator<SemesterCreateDto> _createValidator;

        public SemesterService(IMapper mapper, IUow uow, IValidator<SemesterUpdateDto> updateValidator, IValidator<SemesterCreateDto> createValidator)
        {
            _mapper = mapper;
            _uow = uow;
            _updateValidator = updateValidator;
            _createValidator = createValidator;
        }

        public async Task<IResponse<SemesterCreateDto>> Create(SemesterCreateDto semesterCreateDto)
        {
            var validationResult = _createValidator.Validate(semesterCreateDto);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Semester>().Create(_mapper.Map<Semester>(semesterCreateDto));
                await _uow.SaveChanges();
                return new ResponseT<SemesterCreateDto>(ResponseType.Success, semesterCreateDto);
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
                return new ResponseT<SemesterCreateDto>(ResponseType.ValidationError, semesterCreateDto, errors);
            }
        }

        public async Task<IResponse<List<SemesterListDto>>> GetAll()
        {
            var data = _mapper.Map<List<SemesterListDto>>(await _uow.GetRepository<Semester>().GetAll());
            return new ResponseT<List<SemesterListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<SemesterListDto>> GetById(int id)
        {
            var data = _mapper.Map<SemesterListDto>(await _uow.GetRepository<Semester>().GetByFilter(x => x.IdSemesters == id));
            return new ResponseT<SemesterListDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepository<Semester>().GetByFilter(x => x.IdSemesters == id);
            if (removedEntry != null)
            {
                _uow.GetRepository<Semester>().Remove(removedEntry);
                await _uow.SaveChanges();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<List<SemesterUpdateDto>>> UpdateDtos(SemesterUpdateDto semesterUpdateDto)
        {
            var validationResult = _updateValidator.Validate(semesterUpdateDto);
            if (!validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();
                return new ResponseT<List<SemesterUpdateDto>>(ResponseType.NotFound, "Semester not found.");
            }

            var updatedEntity = await _uow.GetRepository<SemesterUpdateDto>().GetById(semesterUpdateDto.IdSemesters);
            if (updatedEntity != null)
            {
                _uow.GetRepository<SemesterUpdateDto>().Update(_mapper.Map<SemesterUpdateDto>(semesterUpdateDto), updatedEntity);
                await _uow.SaveChanges();
                return new ResponseT<List<SemesterUpdateDto>>(ResponseType.Success, "Semester updated successfully.");
            }
            else
            {
                return new ResponseT<List<SemesterUpdateDto>>(ResponseType.NotFound, "Semester not found.");
            }
        }
    }
}
