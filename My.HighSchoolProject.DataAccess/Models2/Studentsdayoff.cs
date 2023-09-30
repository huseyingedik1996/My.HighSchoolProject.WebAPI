using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models2;

public partial class Studentsdayoff
{
    public int IdStudentsDayoff { get; set; }

    public DateTime Date { get; set; }

    public string Reason { get; set; } = null!;

    public sbyte DoctorReport { get; set; }

    public int IdstudentNumber { get; set; }

    public virtual Student IdstudentNumberNavigation { get; set; } = null!;
}
