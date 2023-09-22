using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models;

public partial class Schoolgeneralinfo
{
    public int IdSchoolGeneralInfo { get; set; }

    public string SchoolName { get; set; } = null!;

    public string SchoolAddress { get; set; } = null!;

    public string SchoolDegree { get; set; } = null!;

    public int FoundationYear { get; set; }

    public string SchoolWebSite { get; set; } = null!;

    public virtual ICollection<Endofsemesterreport> Endofsemesterreports { get; set; } = new List<Endofsemesterreport>();
}
