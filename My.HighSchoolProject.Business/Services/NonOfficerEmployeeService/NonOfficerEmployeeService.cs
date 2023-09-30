using AutoMapper;
using Common.My.HighSchoolProject.WebAPI.Response;
using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.NonOfficerEmployeeDtos;
using FluentValidation;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.DataAccess.Models2;
using My.HighSchoolProject.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.Services.NonOfficerEmployeeService
{
    public class NonOfficerEmployeeService : INonOfficerEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<CreateNonOfficerEmployee> _createValidator;
        private readonly IValidator<UpdateNonOfficerEmployeeDto> _updateValidator;

        public NonOfficerEmployeeService(IMapper mapper, IUow uow, IValidator<CreateNonOfficerEmployee> createValidator, IValidator<UpdateNonOfficerEmployeeDto> updateValidator)
        {
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<CreateNonOfficerEmployee>> Create(CreateNonOfficerEmployee createDto)
        {
            var validationResult = _createValidator.Validate(createDto);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Nonofficeremployee>().Create(_mapper.Map<Nonofficeremployee>(createDto));
                await _uow.SaveChanges();
                return new ResponseT<CreateNonOfficerEmployee>(ResponseType.Success, createDto);
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
                return new ResponseT<CreateNonOfficerEmployee>(ResponseType.ValidationError, createDto, errors);
            }
        }

        public async Task<IResponse<List<ListNonOfficerEmployeeDto>>> GetAll()
        {
            var data = _mapper.Map<List<ListNonOfficerEmployeeDto>>(await _uow.GetRepository<Nonofficeremployee>().GetAll());
            return new ResponseT<List<ListNonOfficerEmployeeDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<ListNonOfficerEmployeeDto>> GetById(int id)
        {
            var data = _mapper.Map<ListNonOfficerEmployeeDto>(await _uow.GetRepository<Nonofficeremployee>().GetByFilter(x => x.IdNonOfficerEmployees == id));
            return new ResponseT<ListNonOfficerEmployeeDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepository<Nonofficeremployee>().GetByFilter(x => x.IdNonOfficerEmployees == id);
            if (removedEntry != null)
            {
                _uow.GetRepository<Nonofficeremployee>().Remove(removedEntry);
                await _uow.SaveChanges();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<List<UpdateNonOfficerEmployeeDto>>> UpdateDtos(UpdateNonOfficerEmployeeDto updateDto)
        {
            var validationResult = _updateValidator.Validate(updateDto);
            if (!validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();
                return new ResponseT<List<UpdateNonOfficerEmployeeDto>>(ResponseType.NotFound, "Employee not found.");
            }

            var updatedEntity = await _uow.GetRepository<UpdateNonOfficerEmployeeDto>().GetById(updateDto.IdNonOfficerEmployees);
            if (updatedEntity != null)
            {
                _uow.GetRepository<UpdateNonOfficerEmployeeDto>().Update(_mapper.Map<UpdateNonOfficerEmployeeDto>(updateDto), updatedEntity);
                await _uow.SaveChanges();
                return new ResponseT<List<UpdateNonOfficerEmployeeDto>>(ResponseType.Success, "Employee updated successfully.");
            }
            else
            {
                return new ResponseT<List<UpdateNonOfficerEmployeeDto>>(ResponseType.NotFound, "Employee not found.");
            }
        }
    }
}
