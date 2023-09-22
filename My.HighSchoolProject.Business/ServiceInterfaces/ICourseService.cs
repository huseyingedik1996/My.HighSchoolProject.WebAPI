using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.CourseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ServiceInterfaces
{
    public interface ICourseService
    {
        Task<IResponse<List<ListCourseDto>>> GetAll();

        Task<IResponse<CreateCourseDto>> Create(CreateCourseDto createCourse);

        Task<IResponse<ListCourseDto>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<List<UpdateCourseDto>>> UpdateDtos(UpdateCourseDto updateCourse);
    }
}
