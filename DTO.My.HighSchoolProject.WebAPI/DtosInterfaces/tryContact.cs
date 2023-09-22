using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.DtosInterfaces
{
    public interface tryContact
    {
        public int IdContacts { get; set; }

        public string StudentsPhone { get; set; }

        public string StudentsEmail { get; set; }

        public string StudentParentPhone { get; set; }
    
        public string StudentsParentEmail { get; set; }

        public string StudentsAddress { get; set; }

        public string? ParentName { get; set; }

        public string? ParentSurname { get; set; }

        public string? City { get; set; }

        public string? Region { get; set; }

        public int IdstudentNumber { get; set; }
    }
}
