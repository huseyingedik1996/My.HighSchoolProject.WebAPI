using DTO.My.HighSchoolProject.WebAPI.Dto.GroupCodeDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.GroupCodeValidation
{
    public class ListGroupCodeValidator : AbstractValidator<ListGroupCodeDto>
    {
        public ListGroupCodeValidator()
        {
            RuleFor(group => group.GroupCode)
            .NotEmpty().WithMessage("Group code is required.")
            .MaximumLength(11).WithMessage("Group code cannot exceed 50 characters.");

            RuleFor(group => group.IdSemesters)
                .NotEmpty().WithMessage("Semester ID is required.");
        }
    }
}
