using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models2;

public partial class Endofsemesterexamscore
{
    public int IdEndOfSemesterScores { get; set; }

    public int IdExamsScore { get; set; }

    public virtual Endofsemesterreport IdEndOfSemesterScoresNavigation { get; set; } = null!;
}
