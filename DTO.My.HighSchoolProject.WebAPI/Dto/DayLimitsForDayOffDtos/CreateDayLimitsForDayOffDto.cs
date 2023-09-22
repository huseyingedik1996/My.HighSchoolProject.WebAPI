using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.DayLimitsForDayOffDtos
{
    public class CreateDayLimitsForDayOffDto : IDtoDayLimitsForDayOffDyo
    {
        public int DayLimitForClass { get; set; }

        public int IdStudentMajorClasses { get; set; }
    }
}
