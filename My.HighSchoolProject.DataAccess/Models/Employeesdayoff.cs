using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models;

public partial class Employeesdayoff
{
    public int IdEmployeesDayOff { get; set; }

    public DateTime Date { get; set; }

    public string Reason { get; set; } = null!;

    public sbyte DoctorReport { get; set; }

    public virtual ICollection<Employee> IdEmployees { get; set; } = new List<Employee>();
}
