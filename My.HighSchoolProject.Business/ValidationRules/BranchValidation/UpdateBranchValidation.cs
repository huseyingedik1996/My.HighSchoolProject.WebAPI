using DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.BranchValidation
{
    public class UpdateBranchValidation : AbstractValidator<UpdateBranchDtos>
    {
        public UpdateBranchValidation()
        {
            RuleFor(x => x.BranchName).NotEmpty().WithMessage("Branch name cannot be empty.").Length(1, 45).WithMessage("Branch name must be between 1 and 45 characters long.");
        }
    }
}
