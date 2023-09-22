using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.DtosInterfaces
{
    public interface IDtoClassroomAndCourse
    {
        public int IdClassGroup { get; set; }

        public int IdMajorsCourses { get; set; }

        public int IdGroupByStudentsMajorAndClasses { get; set; }
    }
}
