using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models2;

public partial class Teacher
{
    public int IdTeachers { get; set; }

    public int IdEmployee { get; set; }

    public int IdBranches { get; set; }

    public int IdResponsibilities { get; set; }

    public virtual ICollection<Courseschedule> Courseschedules { get; set; } = new List<Courseschedule>();

    public virtual ICollection<Examsschedule> Examsschedules { get; set; } = new List<Examsschedule>();

    public virtual Branch IdBranchesNavigation { get; set; } = null!;

    public virtual Employee IdEmployeeNavigation { get; set; } = null!;

    public virtual Responsibility IdResponsibilitiesNavigation { get; set; } = null!;

    public virtual ICollection<TeachersHasCourse> TeachersHasCourses { get; set; } = new List<TeachersHasCourse>();
}
