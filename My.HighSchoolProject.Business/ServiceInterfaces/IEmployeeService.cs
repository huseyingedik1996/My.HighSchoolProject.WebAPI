using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.EmployeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ServiceInterfaces
{
    public interface IEmployeeService
    {
        Task<IResponse<List<ListEmployeeDto>>> GetAll();

        Task<IResponse<CreateEmployeeDto>> Create(CreateEmployeeDto createEmployee);

        Task<IResponse<ListEmployeeDto>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<List<UpdateEmployeeDto>>> UpdateDtos(UpdateEmployeeDto updateEmployee);
    }
}
