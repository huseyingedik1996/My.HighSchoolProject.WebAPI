using DTO.My.HighSchoolProject.WebAPI.Dto.CourseDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.CourseValidations
{
    public class CreateCourseValidator : AbstractValidator<CreateCourseDto>
    {
        public CreateCourseValidator()
        {
            RuleFor(x => x.CourseName).NotEmpty().WithMessage("Course name cannot be empty.").Length(1, 30).WithMessage("Course name must be between 1 and 30 characters long.");
        }
    }
}
