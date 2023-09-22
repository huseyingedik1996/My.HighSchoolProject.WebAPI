using DTO.My.HighSchoolProject.WebAPI.Dto.CourseShcedulesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.DtosInterfaces
{
    public interface IDtoCourseSchedule
    {
        Task<CreateCourseSchedulesDto> Create(CreateCourseSchedulesDto createSchedule);

    }
}
