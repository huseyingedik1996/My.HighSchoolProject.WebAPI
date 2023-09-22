using DTO.My.HighSchoolProject.WebAPI.GetDtos.GroupByStudentsSmC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.GetDtos
{
    public class SampleGetJoinDto : ISampleGetJoinDtos
    {
        public string semester { get; set; }
        public string Majority { get; set; } 
        public int haveClass { get; set; } 
        public string groupCode { get; set; }   
        public int groupCapacity { get; set; } 
        public int studentNumber { get; set; }
        public string studentFullName { get; set; }
    }

}
