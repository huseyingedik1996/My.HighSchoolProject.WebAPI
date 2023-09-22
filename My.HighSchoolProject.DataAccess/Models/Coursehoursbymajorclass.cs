using My.HighSchoolProject.DataAccess.BaseEntities;
using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models;

public partial class Coursehoursbymajorclass : CourseHoursByMajorClass
{
    public int IdMajorsCourses { get; set; }

    public int IdStudentMajorClasses { get; set; }

    public string CourseHourPerWeek { get; set; } = null!;

    public virtual MajorsHasCourse IdMajorsCoursesNavigation { get; set; } = null!;

    public virtual Studentmajorclass IdStudentMajorClassesNavigation { get; set; } = null!;
}
