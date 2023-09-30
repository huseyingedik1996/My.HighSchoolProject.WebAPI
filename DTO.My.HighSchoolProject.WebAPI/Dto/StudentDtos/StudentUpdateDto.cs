using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using My.HighSchoolProject.DataAccess.Models2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.StudentDtos
{
    public class StudentUpdateDto : IDtoStudent
    {
        public int IdstudentNumber { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public int RegistryYear { get; set; }

        public string StudentTc { get; set; } = null!;

        public int? FailCount { get; set; }

        public string RightToEducation { get; set; } = null!;

        public DateTime LastEdit { get; set; }

    }
}
