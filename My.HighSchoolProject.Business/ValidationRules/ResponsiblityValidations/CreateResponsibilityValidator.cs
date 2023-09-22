using DTO.My.HighSchoolProject.WebAPI.Dto.ResponsibilityDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.ResponsiblityValidations
{
    public class CreateResponsibilityValidator : AbstractValidator<CreateResponsibilityDto>
    {
        public CreateResponsibilityValidator()
        {
            RuleFor(e => e.Respobsibility).NotEmpty().WithMessage("Reponsibility cannot be empty.");
        }
    }
}
