using My.HighSchoolProject.DataAccess.BaseEntities;
using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models;

public partial class Studentsdayoff : StudentDayOffBase
{
    public int IdstudentNumber { get; set; }
    public Student IdstudentNumberNavigation { get; set; } = null!;
    public DateTime Date { get; set; }
    public string Reason { get; set; } = null!;
    public sbyte DoctorReport { get; set; }

}
