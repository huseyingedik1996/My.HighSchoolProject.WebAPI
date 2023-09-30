using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using My.HighSchoolProject.DataAccess.Models2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.TeacherHasCoursesDtos
{
    public class ListTeacherHasCoursesDto : IDtoTeacherHasCourses
    {
        public int IdTeacherhasCourses { get; set; }

        public int IdTeachers { get; set; }

        public int IdCourse { get; set; }

        public Teacher Teacher { get; set; }
    }
}
