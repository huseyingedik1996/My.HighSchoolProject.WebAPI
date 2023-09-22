using DTO.My.HighSchoolProject.WebAPI.Dto.GroupCodeDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ValidationRules.GroupCodeValidation
{
    public class CreateGroupCodeValidation : AbstractValidator<CreateGroupCodeDto>
    {
        public CreateGroupCodeValidation()
        {
           
        }
    }

}
