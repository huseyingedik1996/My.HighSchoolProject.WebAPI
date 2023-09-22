using DTO.My.HighSchoolProject.WebAPI.Dto.ClassDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.ClassValidations
{
    public class ClassCreateDtoValidation : AbstractValidator<ClassCreateDto>
    {
        public ClassCreateDtoValidation()
        {
            RuleFor(x => x.ClassNumber).NotNull().GreaterThanOrEqualTo(101).WithMessage("Class number cannot be null and must be higher than 100.");
        }
    }
}
