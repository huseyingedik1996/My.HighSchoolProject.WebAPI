using My.HighSchoolProject.DataAccess.BaseEntities;
using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models2;

public partial class TeachersHasCourse : TeacherHasCoursesBase
{
    public int IdTeachers { get; set; }

    public int IdCourse { get; set; }

    public virtual Course IdCourseNavigation { get; set; } = null!;

    public virtual Teacher IdTeachersNavigation { get; set; } = null!;
}
