using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models;

public partial class Endofsemesteropinionscore
{
    public int IdEndOfSemesterScores { get; set; }

    public int IdTeachersOpinionScores { get; set; }

    public virtual Endofsemesterreport IdEndOfSemesterScoresNavigation { get; set; } = null!;
}
