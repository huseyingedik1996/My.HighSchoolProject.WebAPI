using AutoMapper;
using Common.My.HighSchoolProject.WebAPI.Response;
using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.EmployeeDtos;
using FluentValidation;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.DataAccess.Models2;
using My.HighSchoolProject.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<CreateEmployeeDto> _createValidator;
        private readonly IValidator<UpdateEmployeeDto> _updateValidator;

        public EmployeeService(IMapper mapper, IUow uow, IValidator<UpdateEmployeeDto> updateValidator, IValidator<CreateEmployeeDto> createValidator)
        {
            _mapper = mapper;
            _uow = uow;
            _updateValidator = updateValidator;
            _createValidator = createValidator;
        }

        public async Task<IResponse<CreateEmployeeDto>> Create(CreateEmployeeDto createEmployee)
        {
            var validationResult = _createValidator.Validate(createEmployee);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Employee>().Create(_mapper.Map<Employee>(createEmployee));
                await _uow.SaveChanges();
                return new ResponseT<CreateEmployeeDto>(ResponseType.Success, createEmployee);
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
                return new ResponseT<CreateEmployeeDto>(ResponseType.ValidationError, createEmployee, errors);
            }
        }

        public async Task<IResponse<List<ListEmployeeDto>>> GetAll()
        {
            var data = _mapper.Map<List<ListEmployeeDto>>(await _uow.GetRepository<Employee>().GetAll());
            return new ResponseT<List<ListEmployeeDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<ListEmployeeDto>> GetById(int id)
        {
            var data = _mapper.Map<ListEmployeeDto>(await _uow.GetRepository<Employee>().GetByFilter(x => x.IdEmployee == id));
            return new ResponseT<ListEmployeeDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepository<Employee>().GetByFilter(x => x.IdEmployee == id);
            if (removedEntry != null)
            {
                _uow.GetRepository<Employee>().Remove(removedEntry);
                await _uow.SaveChanges();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<List<UpdateEmployeeDto>>> UpdateDtos(UpdateEmployeeDto updateEmployee)
        {
            var validationResult = _updateValidator.Validate(updateEmployee);
            if (!validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();
                return new ResponseT<List<UpdateEmployeeDto>>(ResponseType.NotFound, "Employee not found.");
            }

            var updatedEntity = await _uow.GetRepository<UpdateEmployeeDto>().GetById(updateEmployee.IdEmployee);
            if (updatedEntity != null)
            {
                _uow.GetRepository<UpdateEmployeeDto>().Update(_mapper.Map<UpdateEmployeeDto>(updateEmployee), updatedEntity);
                await _uow.SaveChanges();
                return new ResponseT<List<UpdateEmployeeDto>>(ResponseType.Success, "Employee updated successfully.");
            }
            else
            {
                return new ResponseT<List<UpdateEmployeeDto>>(ResponseType.NotFound, "Employee not found.");
            }
        }
    }
}