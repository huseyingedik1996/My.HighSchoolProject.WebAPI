using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.DtosInterfaces
{
    public interface IDtoTeacherHasCourses
    {
        public int IdTeachers { get; set; }

        public int IdCourse { get; set; }
    }
}
