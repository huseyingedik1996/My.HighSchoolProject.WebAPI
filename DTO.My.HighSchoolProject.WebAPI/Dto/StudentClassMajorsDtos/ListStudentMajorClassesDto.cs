﻿using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.StudentClassMajorsDtos
{
    public class ListStudentMajorClassesDto : IDtoStudentMajorClasses
    {
        public int IdStudentMajorClasses { get; set; }
        public int IdClasses { get; set; }
        public int IdMajors { get; set; }
        public int IdstudentNumber { get; set; }
    }
}
