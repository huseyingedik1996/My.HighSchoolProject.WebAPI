using AutoMapper;
using Common.My.HighSchoolProject.WebAPI.Response;
using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.MajorDtos;
using FluentValidation;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.DataAccess.Models2;
using My.HighSchoolProject.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.Services.ClassService
{
    public class ClassService : IClassService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<ClassUpdateDto> _updateValidator;
        private readonly IValidator<ClassCreateDto> _createValidator;

        public ClassService(IMapper mapper, IUow uow, IValidator<ClassUpdateDto> updateValidator, IValidator<ClassCreateDto> createValidator)
        {
            _mapper = mapper;
            _uow = uow;
            _updateValidator = updateValidator;
            _createValidator = createValidator;
        }


        public async Task<IResponse<ClassCreateDto>> Create(ClassCreateDto classCreateDto)
        {
            var validationResult = _createValidator.Validate(classCreateDto);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Class>().Create(_mapper.Map<Class>(classCreateDto));
                await _uow.SaveChanges();
                return new ResponseT<ClassCreateDto>(ResponseType.Success, classCreateDto);
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
                return new ResponseT<ClassCreateDto>(ResponseType.ValidationError, classCreateDto, errors);
            }
        }

        public async Task<IResponse<List<ClassListDto>>> GetAll()
        {
            var data = _mapper.Map<List<ClassListDto>>(await _uow.GetRepository<Class>().GetAll());
            return new ResponseT<List<ClassListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<ClassListDto>> GetById(int id)
        {
            var data = _mapper.Map<ClassListDto>(await _uow.GetRepository<Class>().GetByFilter(x => x.IdClasses == id));
            return new ResponseT<ClassListDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepository<Class>().GetByFilter(x => x.IdClasses == id);
            if (removedEntry != null)
            {
                _uow.GetRepository<Class>().Remove(removedEntry);
                await _uow.SaveChanges();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<List<ClassUpdateDto>>> UpdateDtos(ClassUpdateDto classUpdateDto)
        {
            var validationResult = _updateValidator.Validate(classUpdateDto);
            if (!validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();
                return new ResponseT<List<ClassUpdateDto>>(ResponseType.NotFound, "Class not found.");
            }

            var updatedEntity = await _uow.GetRepository<ClassUpdateDto>().GetById(classUpdateDto.IdClasses);
            if (updatedEntity != null)
            {
                _uow.GetRepository<ClassUpdateDto>().Update(_mapper.Map<ClassUpdateDto>(classUpdateDto), updatedEntity);
                await _uow.SaveChanges();
                return new ResponseT<List<ClassUpdateDto>>(ResponseType.Success, "Class updated successfully.");
            }
            else
            {
                return new ResponseT<List<ClassUpdateDto>>(ResponseType.NotFound, "Class not found.");
            }
        }
    }
}
