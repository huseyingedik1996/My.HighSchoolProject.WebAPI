using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.SemesterDtos
{
    public class SemesterListDto : IDtoSemester
    {
        public int IdSemesters { get; set; }
        public string? Semester1 { get; set; }
        public string? Period { get; set; }
    }
}
