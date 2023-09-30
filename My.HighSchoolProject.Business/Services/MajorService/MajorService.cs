using AutoMapper;
using Common.My.HighSchoolProject.WebAPI.Response;
using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.MajorDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentDtos;
using FluentValidation;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.DataAccess.Models2;
using My.HighSchoolProject.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.Services.MajorService
{
    public class MajorService : IMajorService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<MajorCreateDto> _majorCreateValidator;
        private readonly IValidator<MajorUpdateDto> _majorUpdateValidar;

        public MajorService(IMapper mapper, IUow uow, IValidator<MajorCreateDto> majorCreateValidator, IValidator<MajorUpdateDto> majorUpdateValidar)
        {
            _mapper = mapper;
            _uow = uow;
            _majorCreateValidator = majorCreateValidator;
            _majorUpdateValidar = majorUpdateValidar;
        }

        public async Task<IResponse<MajorCreateDto>> Create(MajorCreateDto majorCreateDto)
        {
            var validationResult = _majorCreateValidator.Validate(majorCreateDto);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Major>().Create(_mapper.Map<Major>(majorCreateDto));
                await _uow.SaveChanges();
                return new ResponseT<MajorCreateDto>(ResponseType.Success, majorCreateDto);
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
                return new ResponseT<MajorCreateDto>(ResponseType.ValidationError, majorCreateDto, errors);
            }
        }

        public async Task<IResponse<List<MajorListDto>>> GetAll()
        {
            var data = _mapper.Map<List<MajorListDto>>(await _uow.GetRepository<Major>().GetAll());
            return new ResponseT<List<MajorListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<MajorListDto>> GetById(int id)
        {
            var data = _mapper.Map<MajorListDto>(await _uow.GetRepository<Major>().GetByFilter(x => x.IdMajors ==  id));
            return new ResponseT<MajorListDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepository<Major>().GetByFilter(x => x.IdMajors == id);
            if (removedEntry != null)
            {
                _uow.GetRepository<Major>().Remove(removedEntry);
                await _uow.SaveChanges();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<List<MajorUpdateDto>>> UpdateDtos(MajorUpdateDto majorUpdateDto)
        {
            var validationResult = _majorUpdateValidar.Validate(majorUpdateDto);
            if (validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();
                return new ResponseT<List<MajorUpdateDto>>(ResponseType.NotFound, "Major not found.");
            }

            var updatedEntity = await _uow.GetRepository<MajorUpdateDto>().GetById(majorUpdateDto.IdMajors);
            if (updatedEntity != null)
            {
                _uow.GetRepository<MajorUpdateDto>().Update(_mapper.Map<MajorUpdateDto>(majorUpdateDto), updatedEntity);
                await _uow.SaveChanges();
                return new ResponseT<List<MajorUpdateDto>>(ResponseType.Success, "Major updated successfully.");
            }
            else
            {
                return new ResponseT<List<MajorUpdateDto>>(ResponseType.NotFound, "Major not found.");
            }
        }
    }
}
