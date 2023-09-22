using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.TeacherDtos
{
    public class CreateTeacherDto : IDtoTeacher
    {
        public int IdEmployee { get; set; }

        public int IdBranches { get; set; }

        public int IdResponsibilities { get; set; }
    }
}
