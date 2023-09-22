using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomsGroupDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ServiceInterfaces
{
    public interface IClassroomsGroupService
    {
        Task<IResponse<List<ListClassroomsGroupDto>>> GetAll();

        Task<IResponse<CreateClassroomsGroupDto>> Create(CreateClassroomsGroupDto createClassgroup);

        Task<IResponse<ListClassroomsGroupDto>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<List<UpdateClassroomsGroupDto>>> UpdateDtos(UpdateClassroomsGroupDto updateClassgroup);
    }
}
