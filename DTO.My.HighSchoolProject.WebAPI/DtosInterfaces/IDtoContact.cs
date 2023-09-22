using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.DtosInterfaces
{
    public interface IDtoContact
    {
        int IdstudentNumber { get; set; }

        string StudentsPhone { get; set; } 

        string StudentsEmail { get; set; } 

        string StudentParentPhone { get; set; }

        string StudentsParentEmail { get; set; }

        string StudentsAddress { get; set; }

        string? ParentName { get; set; }

        string? ParentSurname { get; set; }

        string? City { get; set; }

        string? Region { get; set; }
    }
}
