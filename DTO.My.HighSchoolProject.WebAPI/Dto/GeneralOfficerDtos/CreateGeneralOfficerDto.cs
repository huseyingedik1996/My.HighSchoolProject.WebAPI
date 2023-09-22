using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.GeneralOfficerDtos
{
    public class CreateGeneralOfficerDto : IDtoGeneralOfficer
    {
        public int IdEmployee { get; set; }

        public int IdResponsibilities { get; set; }
    }
}
