using My.HighSchoolProject.DataAccess.BaseEntities;

namespace My.HighSchoolProject.DataAccess.Models;

public partial class Daylimitsfordayoff : DayLimitsForDayOffsBase
{
    public int DayLimitForClass { get; set; }

    public int IdStudentMajorClasses { get; set; }

    public virtual Studentmajorclass IdStudentMajorClassesNavigation { get; set; } = null!;
}
