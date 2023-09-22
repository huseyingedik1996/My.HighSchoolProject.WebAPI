using DTO.My.HighSchoolProject.WebAPI.Dto.CourseHoursByMajorClassDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.CoursHoursByMajorClass
{
    public class CreateCourseHoursByMajorClassValidator : AbstractValidator<CreateCourseHoursByMajorClassDto>
    {
        public CreateCourseHoursByMajorClassValidator()
        {
            RuleFor(x => x.CourseHourPerWeek).NotEmpty().WithMessage("Course hour per week cannot be empty.").WithMessage("Course hour per week must be between 1 and 45.");
        }
    }
}
