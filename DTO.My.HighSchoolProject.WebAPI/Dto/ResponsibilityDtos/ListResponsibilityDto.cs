using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.ResponsibilityDtos
{
    public class ListResponsibilityDto : IDtoResponbility
    {
        public int IdResponsibilities { get; set; }
        public string? Respobsibility { get; set; }
    }
}
