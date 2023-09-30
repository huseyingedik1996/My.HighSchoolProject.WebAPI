using DTO.My.HighSchoolProject.WebAPI.Dto.TeacherHasCoursesDtos;
using FluentValidation;
using My.HighSchoolProject.DataAccess.Models2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.TeachersHasCoursesValidations
{
    public class CreateTeacherHasCoursesValidator : AbstractValidator<CreateTeacherHasCoursesDto>
    {
        private readonly HighSchoolDatabaseContext _context;

        public CreateTeacherHasCoursesValidator(HighSchoolDatabaseContext context)
        {
            RuleFor(x => x.IdCourse).NotNull().NotEmpty().WithMessage("Course information cannot be empty.").Must(BeValidTeacherCourse).WithMessage("Teacher and courses branchs does not matched.");
            RuleFor(x => x.IdTeachers).NotNull().NotEmpty().WithMessage("Teacher information cannot be empty.");
            _context = context;
        }

        private bool BeValidTeacherCourse(int arg)
        {
            var isVaild = _context.TeachersHasCourses.Any(x => x.IdTeachersNavigation.IdBranches == x.IdCourseNavigation.IdBranches);
            return isVaild;
        }
    }
}
