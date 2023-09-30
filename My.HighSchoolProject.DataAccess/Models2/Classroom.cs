using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models2;

public partial class Classroom
{
    public int IdClassRooms { get; set; }

    public string ClassRoomName { get; set; } = null!;

    public int ClassRoomCapacity { get; set; }

    public virtual ICollection<Classroomsgroup> Classroomsgroups { get; set; } = new List<Classroomsgroup>();
}
