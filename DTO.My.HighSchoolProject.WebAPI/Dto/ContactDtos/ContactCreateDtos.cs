using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.ContactDtos
{
    public class ContactCreateDtos
    {

        public int IdstudentNumber { get; set; }

        public string StudentsPhone { get; set; } = null!;

        public string StudentsEmail { get; set; } = null!;

        public string StudentParentPhone { get; set; } = null!;

        public string StudentsParentEmail { get; set; } = null!;

        public string StudentsAddress { get; set; } = null!;

        public string? ParentName { get; set; }

        public string? ParentSurname { get; set; }

        public string? City { get; set; }

        public string? Region { get; set; }
    }
}
