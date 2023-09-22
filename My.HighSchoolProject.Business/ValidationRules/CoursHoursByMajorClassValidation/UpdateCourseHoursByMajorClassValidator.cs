using DTO.My.HighSchoolProject.WebAPI.Dto.CourseHoursByMajorClassDto;
using FluentValidation;


namespace My.HighSchoolProject.Business.ValidationRules.CoursHoursByMajorClassValidation
{
    public class UpdateCourseHoursByMajorClassValidator : AbstractValidator<UpdateCourseHoursByMajorClassDto>
    {
        public UpdateCourseHoursByMajorClassValidator()
        {
            RuleFor(x => x.CourseHourPerWeek).NotEmpty().WithMessage("Course hour per week cannot be empty.").WithMessage("Course hour per week must be between 1 and 45.");
        }
    }
}
