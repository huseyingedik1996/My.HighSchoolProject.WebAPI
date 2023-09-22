using My.HighSchoolProject.DataAccess.BaseEntities;
using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models;

public partial class Studentgroupsbyclassandmajor : GroupCodeBase
{
    public string GroupCode { get; set; } = null!;

    public int IdSemesters { get; set; }

    public virtual ICollection<Groupbystudentsmajorandclass> Groupbystudentsmajorandclasses { get; set; } = new List<Groupbystudentsmajorandclass>();

    public virtual Semester IdSemestersNavigation { get; set; } = null!;
}
