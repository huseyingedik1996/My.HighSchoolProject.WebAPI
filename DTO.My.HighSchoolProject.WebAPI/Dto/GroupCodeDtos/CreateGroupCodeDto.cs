﻿using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.GroupCodeDtos
{
    public class CreateGroupCodeDto : IDtoGroupCode
    {
        public string GroupCode { get; set; } = null!;

        public int IdSemesters { get; set; }
    }
}
