using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.ResponsibilityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ServiceInterfaces
{
    public interface IResponsibilityService
    {
        Task<IResponse<List<ListResponsibilityDto>>> GetAll();

        Task<IResponse<CreateResponsibilityDto>> Create(CreateResponsibilityDto createResponsibility);

        Task<IResponse<ListResponsibilityDto>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<List<UpdateResponsibilityDto>>> UpdateDtos(UpdateResponsibilityDto updateResponsibility);
    }
}
