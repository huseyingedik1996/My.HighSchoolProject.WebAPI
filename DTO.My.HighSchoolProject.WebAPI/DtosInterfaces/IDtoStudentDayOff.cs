using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.DtosInterfaces
{
    public interface IDtoStudentDayOff
    {
        public int IdstudentNumber { get; set; }
        public DateTime Date { get; set; }

        public string Reason { get; set; }

        public sbyte DoctorReport { get; set; }
    }
}
