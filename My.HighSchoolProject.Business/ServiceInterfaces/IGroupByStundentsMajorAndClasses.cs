using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.GroupByStudentsMajorAndClass;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ServiceInterfaces
{
    public interface IGroupByStundentsMajorAndClasses
    {
        Task<IResponse<CreateGroupByStudentsMajorAndClass>> Create(CreateGroupByStudentsMajorAndClass  createGroupSmC);

        Task<IResponse> Remove(int id);

        Task<List<UpdateGroupByStudentsMajorAndClass>> UpdateDtos(UpdateGroupByStudentsMajorAndClass updateGroupSmC);
    }
}
