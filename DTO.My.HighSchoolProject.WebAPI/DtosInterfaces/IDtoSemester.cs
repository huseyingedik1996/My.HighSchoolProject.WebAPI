using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.DtosInterfaces
{
    public interface IDtoSemester
    {
        string? Semester1 { get; set; }

        string? Period { get; set; }
    }
}
