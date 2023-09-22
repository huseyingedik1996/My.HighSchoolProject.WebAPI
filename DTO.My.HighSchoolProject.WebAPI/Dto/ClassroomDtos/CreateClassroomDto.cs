using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomDtos
{
    public class CreateClassroomDto : IDtoClassroom
    {
        public string ClassRoomName { get; set; } = null!;

        public int ClassRoomCapacity { get; set; }
    }
}
