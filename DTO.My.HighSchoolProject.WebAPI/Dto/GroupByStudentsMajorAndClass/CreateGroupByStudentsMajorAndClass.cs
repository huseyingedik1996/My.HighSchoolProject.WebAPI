using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.GroupByStudentsMajorAndClass
{
    public class CreateGroupByStudentsMajorAndClass : IDtoGroupByStudentsMajorAndClass
    {
        public int IdMajorClassGroups { get; set; }
        public int GroupCapacity { get; set; }
    }
}
