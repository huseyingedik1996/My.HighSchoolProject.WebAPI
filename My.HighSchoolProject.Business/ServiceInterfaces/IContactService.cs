using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.ContactDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentDtos;
using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ServiceInterfaces
{
    public interface IContactService
    {
        Task<IResponse<List<ContactListDtos>>> GetAll();

        Task<IResponse<ContactCreateDtos>> Create(ContactCreateDtos contactCreateDtos);

        Task<IResponse<ContactListDtos>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<List<ContactUpdateDtos>>> UpdateDtos(ContactUpdateDtos contactUpdateDtos);
    }
}
