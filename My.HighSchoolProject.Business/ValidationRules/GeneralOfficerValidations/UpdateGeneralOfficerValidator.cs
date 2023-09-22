using DTO.My.HighSchoolProject.WebAPI.Dto.GeneralOfficerDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.GeneralOfficerValidations
{
    public class UpdateGeneralOfficerValidator : AbstractValidator<UpdateGeneralOfficerDto>
    {
        public UpdateGeneralOfficerValidator()
        {
            RuleFor(e => e.IdEmployee).NotEmpty().WithMessage("Employee ID cannot be empty.");
            RuleFor(e => e.IdResponsibilities).NotEmpty().WithMessage("Responsibility ID cannot be empty");
        }
    }
}
