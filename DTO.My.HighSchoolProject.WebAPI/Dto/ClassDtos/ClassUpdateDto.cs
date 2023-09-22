using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.ClassDtos
{
    public class ClassUpdateDto : IDtoClass
    {
        public int IdClasses { get; set; }

        public int ClassNumber { get; set; }
    }
}
