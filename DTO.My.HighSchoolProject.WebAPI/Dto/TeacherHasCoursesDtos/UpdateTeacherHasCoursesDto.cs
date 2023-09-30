using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.TeacherHasCoursesDtos
{
    public class UpdateTeacherHasCoursesDto : IDtoTeacherHasCourses
    {
        public int IdTeacherhasCourses { get; set; }

        public int IdTeachers { get; set; }

        public int IdCourse { get; set; }
    }
}
