﻿using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos
{
    public class ListBranchDtos : IDtoBranch
    {
        public int IdBranches { get; set; }

        public string BranchName { get; set; } 
    }
}
