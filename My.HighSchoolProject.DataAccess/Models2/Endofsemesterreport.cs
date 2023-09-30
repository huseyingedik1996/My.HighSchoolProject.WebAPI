using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models2;

public partial class Endofsemesterreport
{
    public int IdEndOfSemesterScores { get; set; }

    public int IdstudentNumber { get; set; }

    public int IdSemester { get; set; }

    public int IdCourse { get; set; }

    public int? AvarageScore { get; set; }

    public int? TotalDayOffWithReport { get; set; }

    public int? TotalDayOfWithoutReport { get; set; }

    public int IdSchoolGeneralInfo { get; set; }

    public virtual Endofsemesterexamscore? Endofsemesterexamscore { get; set; }

    public virtual Endofsemesteropinionscore? Endofsemesteropinionscore { get; set; }

    public virtual Course IdCourseNavigation { get; set; } = null!;

    public virtual Schoolgeneralinfo IdSchoolGeneralInfoNavigation { get; set; } = null!;

    public virtual Semester IdSemesterNavigation { get; set; } = null!;

    public virtual Student IdstudentNumberNavigation { get; set; } = null!;
}
