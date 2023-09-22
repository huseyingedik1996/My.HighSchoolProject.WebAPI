using My.HighSchoolProject.DataAccess.BaseEntities;
using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models;

public partial class Nonofficeremployee : NonOfficerEmployeeBase
{
    public int IdEmployee { get; set; }

    public int IdResponsibilities { get; set; }

    public virtual Employee IdEmployeeNavigation { get; set; } = null!;

    public virtual Responsibility IdResponsibilitiesNavigation { get; set; } = null!;
}
