using DTO.My.HighSchoolProject.WebAPI.Dto.StudentClassMajorsDtos;
using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using My.HighSchoolProject.DataAccess.BaseEntities;
using My.HighSchoolProject.DataAccess.Models2;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.StudentDtos
{
    public class StudentCreateDto : IDtoStudent
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int RegistryYear { get; set; }
        public string StudentTc { get; set; } = null!;
        public int? FailCount { get; set; }
        public string RightToEducation { get; set; } = null!;
        public int IdClass { get; set; }
        public int IdMajor { get; set; }
    }
}
