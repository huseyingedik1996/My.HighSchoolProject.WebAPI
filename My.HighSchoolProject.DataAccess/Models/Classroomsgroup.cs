using My.HighSchoolProject.DataAccess.BaseEntities;
using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models;

public partial class Classroomsgroup : ClassroomsGroupBase
{
    public int IdClass { get; set; }

    public int IdClassRooms { get; set; }

    public int IdSemesters { get; set; }

    public int IdCourse { get; set; }

    public virtual ICollection<Classroomsandcourse> Classroomsandcourses { get; set; } = new List<Classroomsandcourse>();

    public virtual ICollection<Courseschedule> Courseschedules { get; set; } = new List<Courseschedule>();

    public virtual ICollection<Examsschedule> Examsschedules { get; set; } = new List<Examsschedule>();

    public virtual Class IdClassNavigation { get; set; } = null!;

    public virtual Classroom IdClassRoomsNavigation { get; set; } = null!;

    public virtual Course IdCourseNavigation { get; set; } = null!;

    public virtual Semester IdSemestersNavigation { get; set; } = null!;
}
