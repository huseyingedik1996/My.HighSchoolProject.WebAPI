using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models2;

public partial class Classroomsandcourse
{
    public int IdClassRoomsAndGroups { get; set; }

    public int IdClassGroup { get; set; }

    public int IdMajorsCourses { get; set; }

    public int IdGroupByStudentsMajorAndClasses { get; set; }

    public virtual Classroomsgroup IdClassGroupNavigation { get; set; } = null!;

    public virtual Groupbystudentsmajorandclass IdGroupByStudentsMajorAndClassesNavigation { get; set; } = null!;

    public virtual MajorsHasCourse IdMajorsCoursesNavigation { get; set; } = null!;
}
