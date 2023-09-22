using My.HighSchoolProject.DataAccess.BaseEntities;
using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models;

public partial class Groupbystudentsmajorandclass : GroupByStudentsMajorAndClassesBase
{
    public int IdStudentMajorClasses { get; set; }

    public int IdMajorClassGroups { get; set; }

    public int GroupCapacity { get; set; }

    public virtual ICollection<Classroomsandcourse> Classroomsandcourses { get; set; } = new List<Classroomsandcourse>();

    public virtual ICollection<Courseschedule> Courseschedules { get; set; } = new List<Courseschedule>();

    public virtual ICollection<Examsschedule> Examsschedules { get; set; } = new List<Examsschedule>();

    public virtual Studentgroupsbyclassandmajor IdMajorClassGroupsNavigation { get; set; } = null!;

    public virtual Studentmajorclass IdStudentMajorClassesNavigation { get; set; } = null!;
}
