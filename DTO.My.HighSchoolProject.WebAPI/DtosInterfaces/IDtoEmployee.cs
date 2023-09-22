using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.DtosInterfaces
{
    public interface IDtoEmployee
    {
        string Name { get; set; } 

        string Surname { get; set; } 

        string ContactNumber { get; set; } 

        string EmailAdress { get; set; }

        string? HomeAdress { get; set; }

        string PersonalTc { get; set; } 

        float? Wage { get; set; }

        DateTime? RegistryDate { get; set; }

        DateTime? LastEdit { get; set; }
    }
}
