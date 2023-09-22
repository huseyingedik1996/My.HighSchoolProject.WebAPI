using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.DtosInterfaces
{
    public interface IDtoCourseHoursByMajorClass
    {
        public int IdMajorsCourses { get; set; }

        public int IdStudentMajorClasses { get; set; }

        public string CourseHourPerWeek { get; set; }
    }
}
