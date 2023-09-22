using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.StudentDayOffHasStudentsDto
{
    public class StudentDayOffHasStudentsDto : IDtoStudentDayOffHasStudent
    {
        public int idStudentsDayoff { get; set; }
        public int IdstudentNumber { get; set; }
    }
}
