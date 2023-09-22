using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.CourseShcedulesDtos
{
    public class ListCourseSchedulesDto : IDtoCourseSchedules
    {
        public int IdCourseSchedules { get; set; }

        public int IdClassGroup { get; set; }

        public int IdTeachers { get; set; }

        public int IdCourse { get; set; }

        public int IdGroupByStudentsMajorAndClasses { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public string DayOfWeek { get; set; } = null!;
    }
}
