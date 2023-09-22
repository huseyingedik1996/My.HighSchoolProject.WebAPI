using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.EmployeeDtos
{
    public class ListEmployeeDto : IDtoEmployee
    {
        public int IdEmployee { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string ContactNumber { get; set; } = null!;

        public string EmailAdress { get; set; } = null!;

        public string? HomeAdress { get; set; }

        public string PersonalTc { get; set; } = null!;

        public float? Wage { get; set; }

        public DateTime? RegistryDate { get; set; }

        public DateTime? LastEdit { get; set; }
    }
}
