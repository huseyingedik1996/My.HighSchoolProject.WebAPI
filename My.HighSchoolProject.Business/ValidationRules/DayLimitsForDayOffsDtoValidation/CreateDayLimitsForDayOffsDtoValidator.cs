using DTO.My.HighSchoolProject.WebAPI.Dto.DayLimitsForDayOffDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.DayLimitsForDayOffsDtoValidation
{
    public class CreateDayLimitsForDayOffsDtoValidator : AbstractValidator<CreateDayLimitsForDayOffDto>
    {
        public CreateDayLimitsForDayOffsDtoValidator()
        {
            RuleFor(x => x.IdStudentMajorClasses).NotNull().NotEmpty();
        }

    }
}
