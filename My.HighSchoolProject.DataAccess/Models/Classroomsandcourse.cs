using My.HighSchoolProject.DataAccess.BaseEntities;
using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models;

public partial class Classroomsandcourse : ClassroomAndCourseBase
{
    public int IdClassGroup { get; set; }

    public int IdMajorsCourses { get; set; }

    public int IdGroupByStudentsMajorAndClasses { get; set; }

    public virtual Classroomsgroup IdClassGroupNavigation { get; set; } = null!;

    public virtual Groupbystudentsmajorandclass IdGroupByStudentsMajorAndClassesNavigation { get; set; } = null!;

    public virtual MajorsHasCourse IdMajorsCoursesNavigation { get; set; } = null!;
}
