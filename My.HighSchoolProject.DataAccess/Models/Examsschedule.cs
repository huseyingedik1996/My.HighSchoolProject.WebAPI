using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models;

public partial class Examsschedule
{
    public int IdExams { get; set; }

    public int IdCourse { get; set; }

    public int IdSemesters { get; set; }

    public int IdGroupByStudentsMajorAndClasses { get; set; }

    public int IdClassGroup { get; set; }

    public int IdTeachers { get; set; }

    public DateTime ExamDate { get; set; }

    public TimeSpan ExamTime { get; set; }

    public virtual Classroomsgroup IdClassGroupNavigation { get; set; } = null!;

    public virtual Course IdCourseNavigation { get; set; } = null!;

    public virtual Groupbystudentsmajorandclass IdGroupByStudentsMajorAndClassesNavigation { get; set; } = null!;

    public virtual Semester IdSemestersNavigation { get; set; } = null!;

    public virtual Teacher IdTeachersNavigation { get; set; } = null!;
}
