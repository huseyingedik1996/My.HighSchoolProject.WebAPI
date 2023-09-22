using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.GetDtos.StudentJoinDtos
{
    public class StudentGetDayOffJoin
    {
        public int studentNumber { get; set; }
        public string studentFullname { get; set; }
        public List<DayOffInfo> DayOffs { get; set; }
        public int TotalDayOffsWithoutReport { get; set; }
        public int TotalDayOffsWithReport { get ; set; }
    }

    public class DayOffInfo
    {
        public DateTime? DayOffDate { get; set; }
        public int? DayOffReport { get; set; }
        public string DayOffReason { get; set; }
    }
}
