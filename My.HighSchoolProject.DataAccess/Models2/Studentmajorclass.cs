using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models2;

public partial class Studentmajorclass
{
    public int IdStudentMajorClasses { get; set; }

    public int IdClasses { get; set; }

    public int IdMajors { get; set; }

    public int IdstudentNumber { get; set; }

    public virtual ICollection<Coursehoursbymajorclass> Coursehoursbymajorclasses { get; set; } = new List<Coursehoursbymajorclass>();

    public virtual ICollection<Daylimitsfordayoff> Daylimitsfordayoffs { get; set; } = new List<Daylimitsfordayoff>();

    public virtual ICollection<Groupbystudentsmajorandclass> Groupbystudentsmajorandclasses { get; set; } = new List<Groupbystudentsmajorandclass>();

    public virtual Class IdClassesNavigation { get; set; } = null!;

    public virtual Major IdMajorsNavigation { get; set; } = null!;

    public virtual Student IdstudentNumberNavigation { get; set; } = null!;
}
