using AutoMapper;
using Common.My.HighSchoolProject.WebAPI.Response;
using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassDtos;
using FluentValidation;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.DataAccess.Models;
using My.HighSchoolProject.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.Services.BranchService
{
    public class BranchService : IBranchService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<CreateBranchDtos> _createValidator;
        private readonly IValidator<UpdateBranchDtos> _updateValidator;

        public BranchService(IMapper mapper, IUow uow, IValidator<CreateBranchDtos> createValidator, IValidator<UpdateBranchDtos> updateValidator)
        {
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<CreateBranchDtos>> Create(CreateBranchDtos createBranch)
        {
            var validationResult = _createValidator.Validate(createBranch);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Branch>().Create(_mapper.Map<Branch>(createBranch));
                await _uow.SaveChanges();
                return new ResponseT<CreateBranchDtos>(ResponseType.Success, createBranch);
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
                return new ResponseT<CreateBranchDtos>(ResponseType.ValidationError, createBranch, errors);
            }
        }

        public async Task<IResponse<List<ListBranchDtos>>> GetAll()
        {
            var data = _mapper.Map<List<ListBranchDtos>>(await _uow.GetRepository<Branch>().GetAll());
            return new ResponseT<List<ListBranchDtos>>(ResponseType.Success, data);
        }

        public async Task<IResponse<ListBranchDtos>> GetById(int id)
        {
            var data = _mapper.Map<ListBranchDtos>(await _uow.GetRepository<Branch>().GetByFilter(x => x.IdBranches == id));
            return new ResponseT<ListBranchDtos>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepository<Branch>().GetByFilter(x => x.IdBranches == id);
            if (removedEntry != null)
            {
                _uow.GetRepository<Branch>().Remove(removedEntry);
                await _uow.SaveChanges();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<List<UpdateBranchDtos>>> UpdateDtos(UpdateBranchDtos updateBranch)
        {
            var validationResult = _updateValidator.Validate(updateBranch);
            if (!validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();
                return new ResponseT<List<UpdateBranchDtos>>(ResponseType.NotFound, "Branch not found.");
            }

            var updatedEntity = await _uow.GetRepository<UpdateBranchDtos>().GetById(updateBranch.IdBranches);
            if (updatedEntity != null)
            {
                _uow.GetRepository<UpdateBranchDtos>().Update(_mapper.Map<UpdateBranchDtos>(updateBranch), updatedEntity);
                await _uow.SaveChanges();
                return new ResponseT<List<UpdateBranchDtos>>(ResponseType.Success, "Branch updated successfully.");
            }
            else
            {
                return new ResponseT<List<UpdateBranchDtos>>(ResponseType.NotFound, "Branch not found.");
            }
        }
    }
}
