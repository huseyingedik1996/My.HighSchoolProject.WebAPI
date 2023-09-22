using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models;

public partial class TeachersHasCourse
{
    public int IdTeacherhasCourses { get; set; }

    public int IdTeachers { get; set; }

    public int IdCourse { get; set; }
}
