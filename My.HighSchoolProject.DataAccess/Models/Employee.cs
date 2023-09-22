using My.HighSchoolProject.DataAccess.BaseEntities;
using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models;

public partial class Employee : EmployeeBase
{
    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public string EmailAdress { get; set; } = null!;

    public string? HomeAdress { get; set; }

    public string PersonalTc { get; set; } = null!;

    public float? Wage { get; set; }

    public DateTime? RegistryDate { get; set; }

    public DateTime? LastEdit { get; set; }

    public virtual ICollection<Generalofficer> Generalofficers { get; set; } = new List<Generalofficer>();

    public virtual ICollection<Nonofficeremployee> Nonofficeremployees { get; set; } = new List<Nonofficeremployee>();

    public virtual ICollection<Schoolmanagementattendant> Schoolmanagementattendants { get; set; } = new List<Schoolmanagementattendant>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

    public virtual ICollection<Employeesdayoff> IdPersonalsDayoffs { get; set; } = new List<Employeesdayoff>();
}
