using My.HighSchoolProject.DataAccess.BaseEntities;
using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models;

public partial class Class : ClassBase
{
    public int ClassNumber { get; set; }

    public virtual ICollection<Classroomsgroup> Classroomsgroups { get; set; } = new List<Classroomsgroup>();

    public virtual ICollection<MajorsHasCourse> MajorsHasCourses { get; set; } = new List<MajorsHasCourse>();

    public virtual ICollection<Studentmajorclass> Studentmajorclasses { get; set; } = new List<Studentmajorclass>();
}
