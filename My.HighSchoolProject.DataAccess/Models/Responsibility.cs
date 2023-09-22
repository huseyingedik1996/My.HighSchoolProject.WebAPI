using My.HighSchoolProject.DataAccess.BaseEntities;
using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models;

public partial class Responsibility : ReponsibilityBase
{
    public string? Respobsibility { get; set; }

    public virtual ICollection<Generalofficer> Generalofficers { get; set; } = new List<Generalofficer>();

    public virtual ICollection<Nonofficeremployee> Nonofficeremployees { get; set; } = new List<Nonofficeremployee>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

    public virtual ICollection<Schoolmanagementattendant> IdTeachers { get; set; } = new List<Schoolmanagementattendant>();
}
