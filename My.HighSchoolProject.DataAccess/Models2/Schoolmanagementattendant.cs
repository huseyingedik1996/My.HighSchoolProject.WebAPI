using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models2;

public partial class Schoolmanagementattendant
{
    public int IdTeacher { get; set; }

    public int IdEmployee { get; set; }

    public int IdBranches { get; set; }

    public virtual Branch IdBranchesNavigation { get; set; } = null!;

    public virtual Employee IdEmployeeNavigation { get; set; } = null!;

    public virtual ICollection<Responsibility> IdResponsibilities { get; set; } = new List<Responsibility>();
}
