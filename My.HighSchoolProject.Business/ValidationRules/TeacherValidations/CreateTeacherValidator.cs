using DTO.My.HighSchoolProject.WebAPI.Dto.TeacherDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.TeacherValidations
{
    public class CreateTeacherValidator : AbstractValidator<CreateTeacherDto>
    {
        public CreateTeacherValidator()
        {
            RuleFor(e => e.IdBranches).NotEmpty();
            RuleFor(e => e.IdResponsibilities).NotEmpty();
            RuleFor(e => e.IdEmployee).NotEmpty();
        }
    }
}
