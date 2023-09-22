using DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomsGroupDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.ClassroomsGroupValidation
{
    public class CreateClassroomsGroupValidatior : AbstractValidator<CreateClassroomsGroupDto>
    {
        public CreateClassroomsGroupValidatior()
        {
            RuleFor(x => x.IdClass).NotNull().WithMessage("IdClass is required.");
            RuleFor(x => x.IdSemesters).NotNull().WithMessage("IdSemesters is required.");
            RuleFor(x => x.IdCourse).NotNull().WithMessage("IdCourse is required.");
            RuleFor(x => x.IdClassRooms).NotNull().WithMessage("IdClassRooms is required.");
        }
    }
}
