using DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomAndCourseDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.ClassroomAndCourseValidations
{
    public class UpdateClassroomAndCourseValidator : AbstractValidator<UpdateClassroomAndCourseDto>
    {
        public UpdateClassroomAndCourseValidator()
        {
            RuleFor(x => x.IdGroupByStudentsMajorAndClasses).NotNull().WithMessage("IdGroupByStudentsMajorAndClasses is required.");
            RuleFor(x => x.IdClassGroup).NotNull().WithMessage("IdClassGroup is required.");
            RuleFor(x => x.IdMajorsCourses).NotNull().WithMessage("IdMajorsCourses is required.");
        }
    }
}
