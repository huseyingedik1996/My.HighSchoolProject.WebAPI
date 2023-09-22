using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.GroupByStudentsMajorAndClass
{
    public interface IdoListGroupByStudentsMajorAndClass 
    {
        int IdGroupByStudentsMajorAndClasses { get; set; }
        int IdStudentMajorClasses { get; set; }
        int IdMajorClassGroups { get; set; }
        int GroupCapacity { get; set; }
    }
}
