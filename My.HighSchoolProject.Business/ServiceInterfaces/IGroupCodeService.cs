using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.GroupCodeDtos;
using My.HighSchoolProject.DataAccess.Models2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ServiceInterfaces
{
    public interface IGroupCodeService
    {
        Task<IResponse<List<ListGroupCodeDto>>> GetAll();

        Task<CreateGroupCodeDto> Create(CreateGroupCodeDto groupCode);

        Task<IResponse<ListGroupCodeDto>> GetByGroupCode(string groupCode);

        Task<IResponse> Remove(int id);

        Task<IResponse<List<UpdateGroupCodeDto>>> UpdateDtos(UpdateGroupCodeDto groupCode);
    }
}
