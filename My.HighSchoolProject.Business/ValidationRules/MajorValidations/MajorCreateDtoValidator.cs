using DTO.My.HighSchoolProject.WebAPI.Dto.MajorDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.MajorValidations
{
    public class MajorCreateDtoValidator : AbstractValidator<MajorCreateDto>
    {
        public MajorCreateDtoValidator()
        {
            RuleFor(e => e.MajorsName)
            .NotEmpty().WithMessage("Majors name cannot be empty.")
            .MaximumLength(45).WithMessage("Majors name cannot exceed 45 characters.");
        }
    }
}
