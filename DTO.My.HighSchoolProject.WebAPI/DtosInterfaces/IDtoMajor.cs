using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.DtosInterfaces
{
    public interface IDtoMajor
    {
        string MajorsName { get; set; }

        int QuataLimit { get; set; }
    }
}
