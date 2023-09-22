using My.HighSchoolProject.DataAccess.BaseEntities;
using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models;

public partial class Branch : BranchBase
{
    public string BranchName { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Schoolmanagementattendant> Schoolmanagementattendants { get; set; } = new List<Schoolmanagementattendant>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
