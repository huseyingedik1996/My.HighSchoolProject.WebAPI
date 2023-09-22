using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.DtosInterfaces
{
    public interface IDtoClassroomsGroup
    {
        int IdClass { get; set; }

        int IdClassRooms { get; set; }

        int IdSemesters { get; set; }

        int IdCourse { get; set; }
    }
}
