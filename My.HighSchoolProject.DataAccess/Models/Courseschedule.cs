using My.HighSchoolProject.DataAccess.BaseEntities;
using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models;

public partial class Courseschedule : CourseSchedulesBase
{
    public int IdClassGroup { get; set; }

    public int IdTeachers { get; set; }

    public int IdCourse { get; set; }

    public int IdGroupByStudentsMajorAndClasses { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public string DayOfWeek { get; set; } = null!;

    public virtual Classroomsgroup IdClassGroupNavigation { get; set; } = null!;

    public virtual Course IdCourseNavigation { get; set; } = null!;

    public virtual Groupbystudentsmajorandclass IdGroupByStudentsMajorAndClassesNavigation { get; set; } = null!;

    public virtual Teacher IdTeachersNavigation { get; set; } = null!;
}
