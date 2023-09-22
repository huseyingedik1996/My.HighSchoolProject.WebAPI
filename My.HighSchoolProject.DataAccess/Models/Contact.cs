using My.HighSchoolProject.DataAccess.BaseEntities;
using System;
using System.Collections.Generic;

namespace My.HighSchoolProject.DataAccess.Models;

public partial class Contact : ContactBase
{
    //public Contact(string address)
    //{
    //    this.StudentsAddress = address;
    //}


    public string StudentsPhone { get; set; } = null!;

    public string StudentsEmail { get; set; } = null!;

    public string StudentParentPhone { get; set; } = null!;

    public string StudentsParentEmail { get; set; } = null!;

    public string StudentsAddress { get; set; } = null!;

    public string? ParentName { get; set; }

    public string? ParentSurname { get; set; }

    public string? City { get; set; }

    public string? Region { get; set; }

    public int IdstudentNumber { get; set; }

    public virtual Student IdstudentNumberNavigation { get; set; } = null!;
}
