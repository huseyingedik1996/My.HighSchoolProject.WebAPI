using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models2;

public partial class Generalofficer
{
    public int IdGeneralOfficers { get; set; }

    public int IdEmployee { get; set; }

    public int IdResponsibilities { get; set; }

    public virtual Employee IdEmployeeNavigation { get; set; } = null!;

    public virtual Responsibility IdResponsibilitiesNavigation { get; set; } = null!;
}
