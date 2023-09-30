using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models2;

public partial class Major
{
    public int IdMajors { get; set; }

    public string MajorsName { get; set; } = null!;

    public int QuataLimit { get; set; }

    public virtual ICollection<MajorsHasCourse> MajorsHasCourses { get; set; } = new List<MajorsHasCourse>();

    public virtual ICollection<Studentmajorclass> Studentmajorclasses { get; set; } = new List<Studentmajorclass>();
}
