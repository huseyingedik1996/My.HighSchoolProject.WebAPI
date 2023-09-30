using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models2;

public partial class Coursehoursbymajorclass
{
    public int IdCourseHoursByMajorClasses { get; set; }

    public int IdMajorsCourses { get; set; }

    public int IdStudentMajorClasses { get; set; }

    public string CourseHourPerWeek { get; set; } = null!;

    public virtual MajorsHasCourse IdMajorsCoursesNavigation { get; set; } = null!;

    public virtual Studentmajorclass IdStudentMajorClassesNavigation { get; set; } = null!;
}
