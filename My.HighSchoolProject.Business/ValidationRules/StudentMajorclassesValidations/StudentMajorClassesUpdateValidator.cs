using DTO.My.HighSchoolProject.WebAPI.Dto.StudentClassMajorsDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.StudentMajorclassesValidations
{
    public class StudentMajorClassesUpdateValidator : AbstractValidator<UpdateStudonMajorClassesDto>
    {
        public StudentMajorClassesUpdateValidator()
        {
            RuleFor(e => e.IdClasses).NotNull().WithMessage("Class must not be null");
            RuleFor(e => e.IdMajors).NotNull().WithMessage("Major must not be null.");
            RuleFor(e => e.IdstudentNumber).NotNull().WithMessage("Student Number must not be null.");
        }
    }
}
