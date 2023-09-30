using DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomAndCourseDto;
using FluentValidation;
using My.HighSchoolProject.DataAccess.Models2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.ClassroomAndCourseValidations
{
    public class CreateClassroomAndCourseValidatior : AbstractValidator<CreateClassroomAndCourseDto>
    {
        private readonly HighSchoolDatabaseContext _context;

        public CreateClassroomAndCourseValidatior(HighSchoolDatabaseContext context)
        {
            RuleFor(x => x.IdGroupByStudentsMajorAndClasses).NotNull().WithMessage("IdGroupByStudentsMajorAndClasses is required.");
            RuleFor(x => x.IdClassGroup).NotNull().WithMessage("IdClassGroup is required.").Must(BeValidStudentClass).WithMessage("Not found.");
            RuleFor(x => x.IdMajorsCourses).NotNull().WithMessage("IdMajorsCourses is required.").Must(BeValidStudentMajor).WithMessage("Not found");
            _context = context;
        }

        private bool BeValidStudentMajor(int arg)
        {
            var isValid = _context.Classroomsandcourses.Any(a => a.IdMajorsCoursesNavigation.IdMajors == a.IdGroupByStudentsMajorAndClassesNavigation.IdStudentMajorClassesNavigation.IdMajors);
            return isValid;
        }

        private bool BeValidStudentClass(int arg)
        {
            var isValid = _context.Classroomsandcourses.Any(a => a.IdClassGroupNavigation.IdClass == a.IdGroupByStudentsMajorAndClassesNavigation.IdStudentMajorClassesNavigation.IdClasses);
            return isValid;
        }
    }
}
