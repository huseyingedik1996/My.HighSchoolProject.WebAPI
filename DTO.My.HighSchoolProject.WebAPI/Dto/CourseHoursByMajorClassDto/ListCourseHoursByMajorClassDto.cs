using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.CourseHoursByMajorClassDto
{
    public class ListCourseHoursByMajorClassDto : IDtoCourseHoursByMajorClass
    {
        public int IdCourseHoursByMajorClasses { get; set; }

        public int IdMajorsCourses { get; set; }

        public int IdStudentMajorClasses { get; set; }

        public string CourseHourPerWeek { get; set; }
    }
}
