using DTO.My.HighSchoolProject.WebAPI.Dto.NonOfficerEmployeeDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.NonOfficerEmployeeValidations
{
    public class CreateNonOfficerEmployeeValidator : AbstractValidator<CreateNonOfficerEmployee>
    {
        public CreateNonOfficerEmployeeValidator()
        {
            RuleFor(e => e.IdEmployee).NotNull().WithMessage("Employee can not be null.");
        }
    }
}
