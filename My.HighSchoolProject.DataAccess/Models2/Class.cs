using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models2;

public partial class Class
{
    public int IdClasses { get; set; }

    public int ClassNumber { get; set; }

    public virtual ICollection<Classroomsgroup> Classroomsgroups { get; set; } = new List<Classroomsgroup>();

    public virtual ICollection<MajorsHasCourse> MajorsHasCourses { get; set; } = new List<MajorsHasCourse>();

    public virtual ICollection<Studentmajorclass> Studentmajorclasses { get; set; } = new List<Studentmajorclass>();
}
