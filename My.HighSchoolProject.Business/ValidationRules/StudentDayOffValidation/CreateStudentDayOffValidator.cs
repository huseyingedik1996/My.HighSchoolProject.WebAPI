using DTO.My.HighSchoolProject.WebAPI.Dto.StudentDayOffDtos;
using FluentValidation;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.StudentDayOffValidation
{
    public class CreateStudentDayOffValidator : AbstractValidator<CreateStudentDayOffDto>
    {
        public CreateStudentDayOffValidator()
        {
            RuleFor(model => model.Date)
                .NotEmpty().WithMessage("Date is required.")
                .Must(BeAValidDate).WithMessage("Invalid date format.");

            RuleFor(model => model.Reason)
                .NotEmpty().WithMessage("Reason is required.")
                .MaximumLength(45).WithMessage("Reason cannot exceed 45 characters.");
        }

        private bool BeAValidDate(DateTime date)
        {
            return date != DateTime.MinValue; 
        }
    }
}
