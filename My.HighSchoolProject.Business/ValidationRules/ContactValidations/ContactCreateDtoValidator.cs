using DTO.My.HighSchoolProject.WebAPI.Dto.ContactDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentDtos;
using FluentValidation;
using My.HighSchoolProject.DataAccess.Models2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.ContactValidations
{
    public class ContactCreateDtoValidator : AbstractValidator<ContactCreateDtos>
    {
        public ContactCreateDtoValidator()
        {

            RuleFor(d => d.City).NotNull().WithMessage("City must not be null.").MinimumLength(2).MaximumLength(45);
            RuleFor(d => d.ParentName).NotNull().WithMessage("Parent name must not be null.").MinimumLength(2).MaximumLength(30);
            RuleFor(d => d.ParentSurname).NotNull().WithMessage("Parent surname must not be null.").MinimumLength(2).MaximumLength(15);
            RuleFor(d => d.Region).NotNull().WithMessage("Region must not be null.").MinimumLength(2).MaximumLength(45);
            RuleFor(d => d.StudentParentPhone).NotNull().WithMessage("Student parent phone must not be null.").MinimumLength(10).MaximumLength(12);
            RuleFor(d => d.StudentsAddress).NotNull().WithMessage("Students address must not be null.").MinimumLength(2).MaximumLength(250);
            RuleFor(d => d.StudentsEmail).NotNull().WithMessage("Students email must not be null.").EmailAddress();
            RuleFor(d => d.StudentsParentEmail).NotNull().WithMessage("Students parent email must not be null.").EmailAddress();
            RuleFor(d => d.StudentsPhone).NotNull().WithMessage("Students phone must not be null.").MinimumLength(10).MaximumLength(12);
        }
    }
}
