using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.DtosInterfaces
{
    public interface IDtoTeacher
    {
        int IdEmployee { get; set; }

        int IdBranches { get; set; }

        int IdResponsibilities { get; set; }
    }
}
