﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.DtosInterfaces
{
    public interface IDtoMajorHasCourse
    {
        public int IdMajors { get; set; }

        public int IdCourse { get; set; }

        public int IdClasses { get; set; }
    }
}
