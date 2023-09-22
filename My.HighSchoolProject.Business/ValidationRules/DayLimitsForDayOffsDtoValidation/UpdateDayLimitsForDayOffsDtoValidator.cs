using DTO.My.HighSchoolProject.WebAPI.Dto.DayLimitsForDayOffDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.DayLimitsForDayOffsDtoValidation
{
    public class UpdateDayLimitsForDayOffsDtoValidator : AbstractValidator<UpdateDayLimitsForDayOffDtos>
    {
        public UpdateDayLimitsForDayOffsDtoValidator()
        {
            RuleFor(x => x.IdStudentMajorClasses).NotNull().NotEmpty();
        }
    }
}
