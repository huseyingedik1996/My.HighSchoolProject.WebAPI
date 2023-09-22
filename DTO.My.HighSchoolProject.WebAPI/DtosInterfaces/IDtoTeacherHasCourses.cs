using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.DtosInterfaces
{
    public interface IDtoTeacherHasCourses
    {
        int idTeacher { get ; set; }
        int idCourses { get; set; }
    }
}
