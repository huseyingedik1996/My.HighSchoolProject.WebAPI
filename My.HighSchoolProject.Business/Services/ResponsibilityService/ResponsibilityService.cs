using AutoMapper;
using Common.My.HighSchoolProject.WebAPI.Response;
using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.EmployeeDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.ResponsibilityDtos;
using FluentValidation;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.DataAccess.Models;
using My.HighSchoolProject.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.Services.ResponsibilityService
{
    public class ResponsibilityService : IResponsibilityService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<CreateResponsibilityDto> _createValidator;
        private readonly IValidator<UpdateResponsibilityDto> _updateValidator;

        public ResponsibilityService(IMapper mapper, IValidator<CreateResponsibilityDto> createValidator, IValidator<UpdateResponsibilityDto> updateValidator, IUow uow)
        {
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _uow = uow;
        }
        public async Task<IResponse<CreateResponsibilityDto>> Create(CreateResponsibilityDto createResponsibility)
        {
            var validationResult = _createValidator.Validate(createResponsibility);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Responsibility>().Create(_mapper.Map<Responsibility>(createResponsibility));
                await _uow.SaveChanges();
                return new ResponseT<CreateResponsibilityDto>(ResponseType.Success, createResponsibility);
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
                return new ResponseT<CreateResponsibilityDto>(ResponseType.ValidationError, createResponsibility, errors);
            }
        }

        public async Task<IResponse<List<ListResponsibilityDto>>> GetAll()
        {
            var data = _mapper.Map<List<ListResponsibilityDto>>(await _uow.GetRepository<Responsibility>().GetAll());
            return new ResponseT<List<ListResponsibilityDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<ListResponsibilityDto>> GetById(int id)
        {
            var data = _mapper.Map<ListResponsibilityDto>(await _uow.GetRepository<Responsibility>().GetByFilter(x => x.IdResponsibilities == id));
            return new ResponseT<ListResponsibilityDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepository<Responsibility>().GetByFilter(x => x.IdResponsibilities == id);
            if (removedEntry != null)
            {
                _uow.GetRepository<Responsibility>().Remove(removedEntry);
                await _uow.SaveChanges();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<List<UpdateResponsibilityDto>>> UpdateDtos(UpdateResponsibilityDto updateResponsibility)
        {
            var validationResult = _updateValidator.Validate(updateResponsibility);
            if (!validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();
                return new ResponseT<List<UpdateResponsibilityDto>>(ResponseType.NotFound, "Responsibility not found.");
            }

            var updatedEntity = await _uow.GetRepository<UpdateResponsibilityDto>().GetById(updateResponsibility.IdResponsibilities);
            if (updatedEntity != null)
            {
                _uow.GetRepository<UpdateResponsibilityDto>().Update(_mapper.Map<UpdateResponsibilityDto>(updateResponsibility), updatedEntity);
                await _uow.SaveChanges();
                return new ResponseT<List<UpdateResponsibilityDto>>(ResponseType.Success, "Responsibility updated successfully.");
            }
            else
            {
                return new ResponseT<List<UpdateResponsibilityDto>>(ResponseType.NotFound, "Responsibility not found.");
            }
        }
    }
}
