using My.HighSchoolProject.DataAccess.BaseEntities;
using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models;

public partial class Teacher : TeacherBase
{
    public int IdEmployee { get; set; }

    public int IdBranches { get; set; }

    public int IdResponsibilities { get; set; }

    public virtual ICollection<Courseschedule> Courseschedules { get; set; } = new List<Courseschedule>();

    public virtual ICollection<Examsschedule> Examsschedules { get; set; } = new List<Examsschedule>();

    public virtual Branch IdBranchesNavigation { get; set; } = null!;

    public virtual Employee IdEmployeeNavigation { get; set; } = null!;

    public virtual Responsibility IdResponsibilitiesNavigation { get; set; } = null!;

    public virtual Schoolmanagementattendant IdTeachersNavigation { get; set; } = null!;

    public virtual ICollection<Course> IdCourses { get; set; } = new List<Course>();

}
