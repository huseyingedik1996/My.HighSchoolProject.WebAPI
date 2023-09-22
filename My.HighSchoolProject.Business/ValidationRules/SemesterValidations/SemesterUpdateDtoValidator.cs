using DTO.My.HighSchoolProject.WebAPI.Dto.SemesterDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.SemesterValidations
{
    public class SemesterUpdateDtoValidator : AbstractValidator<SemesterUpdateDto>
    {
        public SemesterUpdateDtoValidator()
        {
            RuleFor(e => e.Period).NotNull().MaximumLength(20).WithMessage("Period must not be null.");
            RuleFor(e => e.Semester1).NotNull().MaximumLength(30).WithMessage("Period must not be null.");
        }
    }
}
