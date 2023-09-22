using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.GetDtos.GroupByStudentsSmC
{
    public interface ISampleGetJoinDtos
    {
        string semester { get; set; }
        string Majority { get; set; }
        int haveClass { get; set; }
        string groupCode { get; set; }
        int groupCapacity { get; set; }
        int studentNumber { get; set; }
        string studentFullName { get; set; }
    }
}
