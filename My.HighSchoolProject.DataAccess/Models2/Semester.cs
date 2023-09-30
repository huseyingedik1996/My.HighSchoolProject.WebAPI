using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models2;

public partial class Semester
{
    public int IdSemesters { get; set; }

    public string? Semester1 { get; set; }

    public string? Period { get; set; }

    public virtual ICollection<Classroomsgroup> Classroomsgroups { get; set; } = new List<Classroomsgroup>();

    public virtual ICollection<Endofsemesterreport> Endofsemesterreports { get; set; } = new List<Endofsemesterreport>();

    public virtual ICollection<Examsschedule> Examsschedules { get; set; } = new List<Examsschedule>();

    public virtual ICollection<Studentgroupsbyclassandmajor> Studentgroupsbyclassandmajors { get; set; } = new List<Studentgroupsbyclassandmajor>();
}
