using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models2;

public partial class Daylimitsfordayoff
{
    public int IdDayLimitsForDayOffs { get; set; }

    public int DayLimitForClass { get; set; }

    public int IdStudentMajorClasses { get; set; }

    public virtual Studentmajorclass IdStudentMajorClassesNavigation { get; set; } = null!;
}
