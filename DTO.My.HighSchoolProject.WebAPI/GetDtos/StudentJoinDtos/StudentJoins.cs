using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using My.HighSchoolProject.DataAccess.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.GetDtos.StudentJoinDtos
{
    public class StudentJoins : IStudentJoins
    {
        public string studentTC { get; set; }
        public int studentNumber { get; set; }
        public string studentFullname { get; set; }
        public int? studentFailCount { get; set; }
        public string studentEducationRight { get; set; }
        public string studentMajor { get; set; }
        public int studentClass { get; set; }
        public string? studentGroup { get; set; }
        public StudentContactInfo StudentContactInfo { get; set; }
        
    }
}
