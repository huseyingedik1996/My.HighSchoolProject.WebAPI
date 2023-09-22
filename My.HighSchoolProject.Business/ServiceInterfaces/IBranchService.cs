using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ServiceInterfaces
{
    public interface IBranchService
    {
        Task<IResponse<List<ListBranchDtos>>> GetAll();

        Task<IResponse<CreateBranchDtos>> Create(CreateBranchDtos createBranch);

        Task<IResponse<ListBranchDtos>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<List<UpdateBranchDtos>>> UpdateDtos(UpdateBranchDtos updateBranch);
    }
}
