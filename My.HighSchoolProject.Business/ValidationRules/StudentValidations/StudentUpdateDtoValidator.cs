using DTO.My.HighSchoolProject.WebAPI.Dto.StudentDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.StudentValidations
{
    public class StudentUpdateDtoValidator : AbstractValidator<StudentUpdateDto>
    {
        public StudentUpdateDtoValidator()
        {
            RuleFor(d => d.Name).NotNull().WithMessage("Name must not be null.").MinimumLength(2).MaximumLength(25);
            RuleFor(d => d.Surname).NotNull().WithMessage("Surname must not be null.").MinimumLength(2).MaximumLength(15);
            RuleFor(d => d.RegistryYear).NotNull().WithMessage("Registry year must not be null.");
            RuleFor(d => d.StudentTc).NotNull().WithMessage("Student TC must not be null.").MinimumLength(11).MaximumLength(11);
            RuleFor(d => d.FailCount).NotNull().WithMessage("Fail count must not be null.");
            RuleFor(d => d.RightToEducation).NotNull().WithMessage("Right to education must not be null.").MinimumLength(2).MaximumLength(10);
        }

    }
}

