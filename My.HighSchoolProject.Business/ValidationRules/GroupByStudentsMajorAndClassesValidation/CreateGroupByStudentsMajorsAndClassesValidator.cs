using DTO.My.HighSchoolProject.WebAPI.Dto.GroupByStudentsMajorAndClass;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.GroupByStudentsMajorAndClassesValidation
{
    public class CreateGroupByStudentsMajorsAndClassesValidator : AbstractValidator<CreateGroupByStudentsMajorAndClass>
    {
        public CreateGroupByStudentsMajorsAndClassesValidator()
        {
            RuleFor(e => e.IdMajorClassGroups)
            .NotEmpty().WithMessage("This area must not be null.") 
            .GreaterThan(0).WithMessage("This area must not be null and greater than 0."); 

        }
            
    }
}
