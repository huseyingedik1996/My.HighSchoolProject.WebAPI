using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ServiceInterfaces
{
    public interface IClassroomService
    {
        Task<IResponse<List<ListClassroomDto>>> GetAll();

        Task<IResponse<CreateClassroomDto>> Create(CreateClassroomDto createClassroom);

        Task<IResponse<ListClassroomDto>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<List<UpdateClassroomDto>>> UpdateDtos(UpdateClassroomDto updateClassroom);
    }
}
