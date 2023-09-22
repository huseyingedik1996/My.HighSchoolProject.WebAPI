using My.HighSchoolProject.DataAccess.BaseEntities;
using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models;

public partial class Course : CourseBase
{
    public string CourseName { get; set; } = null!;

    public int IdBranches { get; set; }

    public virtual ICollection<Classroomsgroup> Classroomsgroups { get; set; } = new List<Classroomsgroup>();

    public virtual ICollection<Courseschedule> Courseschedules { get; set; } = new List<Courseschedule>();

    public virtual ICollection<Endofsemesterreport> Endofsemesterreports { get; set; } = new List<Endofsemesterreport>();

    public virtual ICollection<Examsschedule> Examsschedules { get; set; } = new List<Examsschedule>();

    public virtual Branch IdBranchesNavigation { get; set; } = null!;

    public virtual ICollection<MajorsHasCourse> MajorsHasCourses { get; set; } = new List<MajorsHasCourse>();

    public virtual ICollection<Teacher> IdTeachers { get; set; } = new List<Teacher>();

}
