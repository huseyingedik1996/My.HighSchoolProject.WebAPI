using DTO.My.HighSchoolProject.WebAPI.Dto.EmployeeDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.EmployeeValidations
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeDto>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(e => e.ContactNumber)
            .NotEmpty().WithMessage("Contact number is required.")
            .MaximumLength(12).WithMessage("Contact number cannot exceed 12 characters.");

            RuleFor(e => e.EmailAdress)
                .NotEmpty().WithMessage("Email address is required.")
                .MaximumLength(45).WithMessage("Email address cannot exceed 45 characters.");

            RuleFor(e => e.PersonalTc)
                .NotEmpty().WithMessage("Personal TC is required.")
                .Length(11).WithMessage("Personal TC must be exactly 11 characters.");

            RuleFor(e => e.HomeAdress)
                .MaximumLength(250).WithMessage("Home address cannot exceed 250 characters.");

            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(25).WithMessage("Name cannot exceed 25 characters.");

            RuleFor(e => e.Surname)
                .MaximumLength(18).WithMessage("Surname cannot exceed 18 characters.");

            RuleFor(e => e.RegistryDate).NotEmpty().WithMessage("Date is required.");

        }
    }
}
