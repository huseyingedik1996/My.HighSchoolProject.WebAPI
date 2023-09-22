using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.DtosInterfaces
{
    public interface IDtoGroupByStudentsMajorAndClass
    {

        int IdMajorClassGroups { get; set; }

        int GroupCapacity { get; set; }
    }
}
