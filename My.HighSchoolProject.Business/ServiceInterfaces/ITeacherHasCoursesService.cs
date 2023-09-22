using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.TeacherHasCoursesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ServiceInterfaces
{
    public interface ITeacherHasCoursesService
    {
        Task<IResponse<List<ListTeacherHasCoursesDto>>> GetAll();

        Task<IResponse<CreateTeacherHasCoursesDto>> Create(CreateTeacherHasCoursesDto createDto);

        Task<IResponse<ListTeacherHasCoursesDto>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<List<UpdateTeacherHasCoursesDto>>> UpdateDtos(UpdateTeacherHasCoursesDto updateDto);
    }
}
