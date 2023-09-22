using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.ResponsibilityDtos
{
    public class CreateResponsibilityDto : IDtoResponbility
    {
        public string? Respobsibility { get; set; }
    }
}
