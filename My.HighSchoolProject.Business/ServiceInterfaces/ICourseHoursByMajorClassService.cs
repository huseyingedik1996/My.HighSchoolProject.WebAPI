using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.CourseHoursByMajorClassDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ServiceInterfaces
{
    public interface ICourseHoursByMajorClassService
    {
        Task<IResponse<List<ListCourseHoursByMajorClassDto>>> GetAll();

        Task<IResponse<CreateCourseHoursByMajorClassDto>> Create(CreateCourseHoursByMajorClassDto createCoursehours);

        Task<IResponse<ListCourseHoursByMajorClassDto>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<List<UpdateCourseHoursByMajorClassDto>>> UpdateDtos(UpdateCourseHoursByMajorClassDto updateCoursehours);
    }
}
