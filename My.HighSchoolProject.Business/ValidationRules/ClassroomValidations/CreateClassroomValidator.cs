using DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.ClassroomValidations
{
    public class CreateClassroomValidator : AbstractValidator<CreateClassroomDto>
    {
        public CreateClassroomValidator()
        {
            RuleFor(e => e.ClassRoomName)
           .NotEmpty().WithMessage("Classroom name cannot be empty.")
           .Length(1, 20).WithMessage("Classroom name must be between 1 and 20 characters.");
        }
    }
}
