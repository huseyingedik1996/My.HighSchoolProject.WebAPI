using My.HighSchoolProject.DataAccess.BaseEntities;
using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models;

public partial class MajorsHasCourse : MajorHasCourseBase
{
    public int IdMajors { get; set; }

    public int IdCourse { get; set; }

    public int IdClasses { get; set; }

    public virtual ICollection<Classroomsandcourse> Classroomsandcourses { get; set; } = new List<Classroomsandcourse>();

    public virtual ICollection<Coursehoursbymajorclass> Coursehoursbymajorclasses { get; set; } = new List<Coursehoursbymajorclass>();

    public virtual Class IdClassesNavigation { get; set; } = null!;

    public virtual Course IdCourseNavigation { get; set; } = null!;

    public virtual Major IdMajorsNavigation { get; set; } = null!;
}
