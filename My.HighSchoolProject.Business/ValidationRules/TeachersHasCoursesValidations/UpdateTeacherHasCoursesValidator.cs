using DTO.My.HighSchoolProject.WebAPI.Dto.TeacherHasCoursesDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.TeachersHasCoursesValidations
{
    public class UpdateTeacherHasCoursesValidator : AbstractValidator<UpdateTeacherHasCoursesDto>
    {
        public UpdateTeacherHasCoursesValidator()
        {
            RuleFor(x => x.IdCourse).NotNull().NotEmpty().WithMessage("Course information cannot be empty.");
            RuleFor(x => x.IdTeachers).NotNull().NotEmpty().WithMessage("Teacher information cannot be empty.");
        }
    }
}
