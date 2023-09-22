using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomsGroupDtos
{
    public class CreateClassroomsGroupDto : IDtoClassroomsGroup
    {
        public int IdClass { get; set; }

        public int IdClassRooms { get; set; }

        public int IdSemesters { get; set; }

        public int IdCourse { get; set; }
    }
}
