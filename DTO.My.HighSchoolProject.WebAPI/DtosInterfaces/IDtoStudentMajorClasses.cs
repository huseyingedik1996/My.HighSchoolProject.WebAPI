using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.DtosInterfaces
{
    public interface IDtoStudentMajorClasses
    {
        int IdstudentNumber { get; set; }

        int IdClasses { get; set; }

        int IdMajors { get; set; }

    }
}
