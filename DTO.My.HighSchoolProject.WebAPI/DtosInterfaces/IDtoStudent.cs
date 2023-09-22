using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.DtosInterfaces
{
    public interface IDtoStudent
    {
        string Name { get; set; } 
        string Surname { get; set; }
        int RegistryYear { get; set; }
        string StudentTc { get; set; }
        int? FailCount { get; set; }
        string RightToEducation { get; set; }
    }
}
