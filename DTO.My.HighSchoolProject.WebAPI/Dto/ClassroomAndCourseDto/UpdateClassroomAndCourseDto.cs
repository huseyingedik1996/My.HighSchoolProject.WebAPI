﻿using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomAndCourseDto
{
    public class UpdateClassroomAndCourseDto : IDtoClassroomAndCourse
    {
        public int IdClassRoomsAndGroups { get; set; }

        public int IdClassGroup { get; set; }

        public int IdMajorsCourses { get; set; }

        public int IdGroupByStudentsMajorAndClasses { get; set; }
    }
}