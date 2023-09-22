using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomAndCourseDto;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomsGroupDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ServiceInterfaces
{
    public interface IClassroomAndGroupService
    {
        Task<IResponse<List<ListClassroomAndCourseDto>>> GetAll();

        Task<IResponse<CreateClassroomAndCourseDto>> Create(CreateClassroomAndCourseDto createClassCourse);

        Task<IResponse<ListClassroomAndCourseDto>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<List<UpdateClassroomAndCourseDto>>> UpdateDtos(UpdateClassroomAndCourseDto updateClassCourse);
    }
}
