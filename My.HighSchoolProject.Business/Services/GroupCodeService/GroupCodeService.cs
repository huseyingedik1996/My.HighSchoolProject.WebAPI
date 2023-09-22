using AutoMapper;
using Common.My.HighSchoolProject.WebAPI.Response;
using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.GroupCodeDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.MajorDtos;
using FluentValidation;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.DataAccess.Models;
using My.HighSchoolProject.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.Services.GroupCodeService
{
    public class GroupCodeService : IGroupCodeService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<CreateGroupCodeDto> _createGroupCodeValidator;
        private readonly IValidator<UpdateGroupCodeDto> _updateGroupCodeValidator;

        public GroupCodeService(IMapper mapper, IUow uow, IValidator<CreateGroupCodeDto> createGroupCodeValidator, IValidator<UpdateGroupCodeDto> updateGroupCodeValidator)
        {
            _mapper = mapper;
            _uow = uow;
            _createGroupCodeValidator = createGroupCodeValidator;
            _updateGroupCodeValidator = updateGroupCodeValidator;
        }

        public async Task<CreateGroupCodeDto> Create(CreateGroupCodeDto groupCode)
        {

            await _uow.GetRepository<Studentgroupsbyclassandmajor>().Create(_mapper.Map<Studentgroupsbyclassandmajor>(groupCode));
            await _uow.SaveChanges();
            return groupCode;

        }

        public async Task<IResponse<List<ListGroupCodeDto>>> GetAll()
        {
            var data = _mapper.Map<List<ListGroupCodeDto>>(await _uow.GetRepository<Studentgroupsbyclassandmajor>().GetAll());
            return new ResponseT<List<ListGroupCodeDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<ListGroupCodeDto>> GetByGroupCode(string groupCode)
        {
            
            var data = _mapper.Map<ListGroupCodeDto>(await _uow.GetRepository<Studentgroupsbyclassandmajor>().GetByFilter(x => x.GroupCode == groupCode));
            return new ResponseT<ListGroupCodeDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepository<Studentgroupsbyclassandmajor>().GetByFilter(x => x.IdMajorClassGroups == id);
            if (removedEntry != null)
            {
                _uow.GetRepository<Studentgroupsbyclassandmajor>().Remove(removedEntry);
                await _uow.SaveChanges();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<List<UpdateGroupCodeDto>>> UpdateDtos(UpdateGroupCodeDto groupCodeDto)
        {
            var validationResult = _updateGroupCodeValidator.Validate(groupCodeDto);
            if (!validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();
                return new ResponseT<List<UpdateGroupCodeDto>>(ResponseType.NotFound, "Group not found.");
            }

            var updatedEntity = await _uow.GetRepository<UpdateGroupCodeDto>().GetById(groupCodeDto.IdMajorClassGroups);
            if (updatedEntity != null)
            {
                _uow.GetRepository<UpdateGroupCodeDto>().Update(_mapper.Map<UpdateGroupCodeDto>(groupCodeDto), updatedEntity);
                await _uow.SaveChanges();
                return new ResponseT<List<UpdateGroupCodeDto>>(ResponseType.Success, "Group updated successfully.");
            }
            else
            {
                return new ResponseT<List<UpdateGroupCodeDto>>(ResponseType.NotFound, "Group not found.");
            }
        }
    }
}
