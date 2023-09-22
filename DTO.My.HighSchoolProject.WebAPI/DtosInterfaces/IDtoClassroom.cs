using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.DtosInterfaces
{
    public interface IDtoClassroom
    {
       string ClassRoomName { get; set; } 

       int ClassRoomCapacity { get; set; }
    }
}
