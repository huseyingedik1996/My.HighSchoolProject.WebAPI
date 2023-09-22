using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.StudentDayOffDtos
{
    public class UpdateStudentDayOfDto : IDtoStudentDayOff
    {
        public int IdStudentsDayoff { get; set; }
        public int IdstudentNumber { get; set; }
        public DateTime Date { get; set; }

        public string Reason { get; set; } = null!;

        public sbyte DoctorReport { get; set; }
    }
}
