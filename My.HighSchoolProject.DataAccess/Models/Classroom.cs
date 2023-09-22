using My.HighSchoolProject.DataAccess.BaseEntities;
using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models;

public partial class Classroom : ClassroomBase
{
    public string ClassRoomName { get; set; } = null!;

    public int ClassRoomCapacity { get; set; }

    public virtual ICollection<Classroomsgroup> Classroomsgroups { get; set; } = new List<Classroomsgroup>();
}
