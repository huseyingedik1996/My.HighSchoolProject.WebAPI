using DTO.My.HighSchoolProject.WebAPI.Dto.NonOfficerEmployeeDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.NonOfficerEmployeeValidations
{
    public class UpdateNonOfficerEmployeeValidator : AbstractValidator<UpdateNonOfficerEmployeeDto>
    {
        public UpdateNonOfficerEmployeeValidator()
        {
            RuleFor(e => e.IdEmployee).NotNull().WithMessage("Employee can not be null.");
        }
    }
}
