using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.CourseDto
{
    public class ListCourseDto
    {
        public int IdCourse { get; set; }

        public string CourseName { get; set; } = null!;

        public int IdBranches { get; set; }
    }
}
