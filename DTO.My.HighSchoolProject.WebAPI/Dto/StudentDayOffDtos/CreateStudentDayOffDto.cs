using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using My.HighSchoolProject.DataAccess.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.StudentDayOffDtos
{
    public class CreateStudentDayOffDto : IDtoStudentDayOff
    {
        public int IdstudentNumber { get; set; }

        public DateTime Date { get; set; }

        public string Reason { get; set; } = null!;

        public sbyte DoctorReport { get; set; }

    }
}
