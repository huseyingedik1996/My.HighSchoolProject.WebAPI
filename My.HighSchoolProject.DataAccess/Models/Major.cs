using My.HighSchoolProject.DataAccess.BaseEntities;
using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models;

public partial class Major : MajorBase
{
   
    public string MajorsName { get; set; } = null!;

    public int QuataLimit { get; set; }

    public virtual ICollection<MajorsHasCourse> MajorsHasCourses { get; set; } = new List<MajorsHasCourse>();

    public virtual ICollection<Studentmajorclass> Studentmajorclasses { get; set; } = new List<Studentmajorclass>();
}
