using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using My.HighSchoolProject.DataAccess.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.StudentClassMajorsDtos
{
    public class CreateStudentMajorClassesDto : IDtoStudentMajorClasses
    {   
        public int IdstudentNumber { get; set; }
        public int IdClasses { get; set; } 
        public int IdMajors { get; set; }       
    }
}
