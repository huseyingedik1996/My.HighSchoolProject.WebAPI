using AutoMapper;
using Azure;
using Common.My.HighSchoolProject.WebAPI.Response;
using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.ContactDtos;
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

namespace My.HighSchoolProject.Business.Services.ContactService
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<ContactCreateDtos> _contactCreateValidator;
        private readonly IValidator<ContactUpdateDtos> _updateContactValidator;

        public ContactService(IMapper mapper, IUow uow, IValidator<ContactCreateDtos> contactCreateValidator, IValidator<ContactUpdateDtos> updateContactValidator)
        {
            _mapper = mapper;
            _uow = uow;
            _contactCreateValidator = contactCreateValidator;
            _updateContactValidator = updateContactValidator;
        }

        public async Task<IResponse<ContactCreateDtos>> Create(ContactCreateDtos contactCreateDtos)
        {
            var validationResult = _contactCreateValidator.Validate(contactCreateDtos);

            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Contact>().Create(_mapper.Map<Contact>(contactCreateDtos));
                await _uow.SaveChanges();
                return new ResponseT<ContactCreateDtos>(ResponseType.Success, contactCreateDtos);
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
                return new ResponseT<ContactCreateDtos>(ResponseType.ValidationError, contactCreateDtos, errors);
            }
        }

        public async Task<IResponse<List<ContactListDtos>>> GetAll()
        {
            var data = _mapper.Map<List<ContactListDtos>>(await _uow.GetRepository<Contact>().GetAll());
            return new ResponseT<List<ContactListDtos>>(ResponseType.Success, data);
        }

        public async Task<IResponse<ContactListDtos>> GetById(int id)
        {
            var data = _mapper.Map<ContactListDtos>(await _uow.GetRepository<Contact>().GetByFilter(x => x.IdContacts == id));
            return new ResponseT<ContactListDtos>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepository<Contact>().GetByFilter(x => x.IdContacts == id);
            if (removedEntry != null)
            {
                _uow.GetRepository<Contact>().Remove(removedEntry);
                await _uow.SaveChanges();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.Success, $"{id} not found.");
        }

        public async Task<IResponse<List<ContactUpdateDtos>>> UpdateDtos(ContactUpdateDtos contactUpdateDtos)
        {
            var validationResult = _updateContactValidator.Validate(contactUpdateDtos);
            if (!validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();
                return new ResponseT<List<ContactUpdateDtos>>(ResponseType.NotFound, "Contact not found.");
            }
            var updatedEntity = await _uow.GetRepository<ContactUpdateDtos>().GetById(contactUpdateDtos.IdContacts);
            if (updatedEntity != null)
            {
                _uow.GetRepository<ContactUpdateDtos>().Update(_mapper.Map<ContactUpdateDtos>(contactUpdateDtos), updatedEntity);
                await _uow.SaveChanges();
                return new ResponseT<List<ContactUpdateDtos>>(ResponseType.Success, "Contact updated successfully.");
            }
            else
            {
                return new ResponseT<List<ContactUpdateDtos>>(ResponseType.NotFound,"Contact not found.");
            }
        }
    }
}
