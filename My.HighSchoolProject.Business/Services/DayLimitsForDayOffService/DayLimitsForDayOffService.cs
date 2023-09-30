using AutoMapper;
using Common.My.HighSchoolProject.WebAPI.Response;
using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.DayLimitsForDayOffDtos;
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

namespace My.HighSchoolProject.Business.Services.DayLimitsForDayOffService
{
    public class DayLimitsForDayOffService : IDayLimitsForDayOffService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<CreateDayLimitsForDayOffDto> validatorCreateDayLimits;
        private readonly IValidator<UpdateDayLimitsForDayOffDtos> validatorUpdateDayLimits;

        public DayLimitsForDayOffService(IMapper mapper, IUow uow, IValidator<CreateDayLimitsForDayOffDto> validatorCreateDayLimits, IValidator<UpdateDayLimitsForDayOffDtos> validatorUpdateDayLimits)
        {
            _mapper = mapper;
            _uow = uow;
            this.validatorCreateDayLimits = validatorCreateDayLimits;
            this.validatorUpdateDayLimits = validatorUpdateDayLimits;
        }

        public async Task<IResponse<CreateDayLimitsForDayOffDto>> Create(CreateDayLimitsForDayOffDto createDayLimits)
        {
            var validationResult = validatorCreateDayLimits.Validate(createDayLimits);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Daylimitsfordayoff>().Create(_mapper.Map<Daylimitsfordayoff>(createDayLimits));
                await _uow.SaveChanges();
                return new ResponseT<CreateDayLimitsForDayOffDto>(ResponseType.Success, createDayLimits);
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
                return new ResponseT<CreateDayLimitsForDayOffDto>(ResponseType.ValidationError, createDayLimits, errors);
            }
        }

        public async Task<IResponse<List<ListDayLimitsForDayOffDtos>>> GetAll()
        {
            var data = _mapper.Map<List<ListDayLimitsForDayOffDtos>>(await _uow.GetRepository<Daylimitsfordayoff>().GetAll());
            return new ResponseT<List<ListDayLimitsForDayOffDtos>>(ResponseType.Success, data);
        }

        public async Task<IResponse<ListDayLimitsForDayOffDtos>> GetById(int id)
        {
            var data = _mapper.Map<ListDayLimitsForDayOffDtos>(await _uow.GetRepository<Daylimitsfordayoff>().GetByFilter(x => x.IdDayLimitsForDayOffs == id));
            return new ResponseT<ListDayLimitsForDayOffDtos>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepository<Daylimitsfordayoff>().GetByFilter(x => x.IdDayLimitsForDayOffs == id);
            if (removedEntry != null)
            {
                _uow.GetRepository<Daylimitsfordayoff>().Remove(removedEntry);
                await _uow.SaveChanges();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<List<UpdateDayLimitsForDayOffDtos>>> UpdateDtos(UpdateDayLimitsForDayOffDtos updateDayLimits)
        {
            var validationResult = validatorUpdateDayLimits.Validate(updateDayLimits);
            if (validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();
                return new ResponseT<List<UpdateDayLimitsForDayOffDtos>>(ResponseType.NotFound, "- not found.");
            }

            var updatedEntity = await _uow.GetRepository<UpdateDayLimitsForDayOffDtos>().GetById(updateDayLimits.IdDayLimitsForDayOffs);
            if (updatedEntity != null)
            {
                _uow.GetRepository<UpdateDayLimitsForDayOffDtos>().Update(_mapper.Map<UpdateDayLimitsForDayOffDtos>(updateDayLimits), updatedEntity);
                await _uow.SaveChanges();
                return new ResponseT<List<UpdateDayLimitsForDayOffDtos>>(ResponseType.Success, "Limit updated successfully.");
            }
            else
            {
                return new ResponseT<List<UpdateDayLimitsForDayOffDtos>>(ResponseType.NotFound, "- not found.");
            }
        }
    }
}
