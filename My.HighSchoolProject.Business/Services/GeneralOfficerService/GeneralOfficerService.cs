using AutoMapper;
using Common.My.HighSchoolProject.WebAPI.Response;
using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.GeneralOfficerDtos;
using FluentValidation;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.DataAccess.Models;
using My.HighSchoolProject.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.Services.GeneralOfficerService
{
    public class GeneralOfficerService : IGeneralOfficerService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<CreateGeneralOfficerDto> _createValidator;
        private readonly IValidator<UpdateGeneralOfficerDto?> _updateValidator;

        public GeneralOfficerService(IMapper mapper, IUow uow, IValidator<CreateGeneralOfficerDto> createValidator, IValidator<UpdateGeneralOfficerDto?> updateValidator)
        {
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<CreateGeneralOfficerDto>> Create(CreateGeneralOfficerDto createDto)
        {
            var validationResult = _createValidator.Validate(createDto);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Generalofficer>().Create(_mapper.Map<Generalofficer>(createDto));
                await _uow.SaveChanges();
                return new ResponseT<CreateGeneralOfficerDto>(ResponseType.Success, createDto);
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
                return new ResponseT<CreateGeneralOfficerDto>(ResponseType.ValidationError, createDto, errors);
            }
        }

        public async Task<IResponse<List<ListGeneralOfficerDto>>> GetAll()
        {
            var data = _mapper.Map<List<ListGeneralOfficerDto>>(await _uow.GetRepository<Generalofficer>().GetAll());
            return new ResponseT<List<ListGeneralOfficerDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<ListGeneralOfficerDto>> GetById(int id)
        {
            var data = _mapper.Map<ListGeneralOfficerDto>(await _uow.GetRepository<Generalofficer>().GetByFilter(x => x.IdGeneralOfficers == id));
            return new ResponseT<ListGeneralOfficerDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepository<Generalofficer>().GetByFilter(x => x.IdGeneralOfficers == id);
            if (removedEntry != null)
            {
                _uow.GetRepository<Generalofficer>().Remove(removedEntry);
                await _uow.SaveChanges();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<List<UpdateGeneralOfficerDto>>> UpdateDtos(UpdateGeneralOfficerDto updateDto)
        {
            var validationResult = _updateValidator.Validate(updateDto);
            if (!validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();
                return new ResponseT<List<UpdateGeneralOfficerDto>>(ResponseType.NotFound, "General officer not found.");
            }

            var updatedEntity = await _uow.GetRepository<UpdateGeneralOfficerDto>().GetById(updateDto.IdGeneralOfficers);
            if (updatedEntity != null)
            {
                _uow.GetRepository<UpdateGeneralOfficerDto>().Update(_mapper.Map<UpdateGeneralOfficerDto>(updateDto), updatedEntity);
                await _uow.SaveChanges();
                return new ResponseT<List<UpdateGeneralOfficerDto>>(ResponseType.Success, "General officer updated successfully.");
            }
            else
            {
                return new ResponseT<List<UpdateGeneralOfficerDto>>(ResponseType.NotFound, "General officer not found.");
            }
        }
    }
}
