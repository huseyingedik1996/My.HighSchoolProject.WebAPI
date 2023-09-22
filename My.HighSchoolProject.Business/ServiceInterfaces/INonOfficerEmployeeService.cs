using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.NonOfficerEmployeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ServiceInterfaces
{
    public interface INonOfficerEmployeeService
    {
        Task<IResponse<List<ListNonOfficerEmployeeDto>>> GetAll();

        Task<IResponse<CreateNonOfficerEmployee>> Create(CreateNonOfficerEmployee createDto);

        Task<IResponse<ListNonOfficerEmployeeDto>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<List<UpdateNonOfficerEmployeeDto>>> UpdateDtos(UpdateNonOfficerEmployeeDto updateDto);
    }
}
