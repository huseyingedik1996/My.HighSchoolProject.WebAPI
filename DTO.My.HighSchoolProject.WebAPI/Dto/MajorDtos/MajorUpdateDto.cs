﻿using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.MajorDtos
{
    public class MajorUpdateDto : IDtoMajor
    {
        public int IdMajors { get; set; }
        public string MajorsName { get; set; }
        public int QuataLimit { get; set; }
    }
}
