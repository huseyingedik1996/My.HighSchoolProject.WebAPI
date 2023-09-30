using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models2;

public partial class Student
{
    public int IdstudentNumber { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public int RegistryYear { get; set; }

    public string StudentTc { get; set; } = null!;

    public int? FailCount { get; set; }

    public string RightToEducation { get; set; } = null!;

    public DateTime LastEdit { get; set; }

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<Endofsemesterreport> Endofsemesterreports { get; set; } = new List<Endofsemesterreport>();

    public virtual ICollection<Studentmajorclass> Studentmajorclasses { get; set; } = new List<Studentmajorclass>();

    public virtual ICollection<Studentsdayoff> Studentsdayoffs { get; set; } = new List<Studentsdayoff>();
}
