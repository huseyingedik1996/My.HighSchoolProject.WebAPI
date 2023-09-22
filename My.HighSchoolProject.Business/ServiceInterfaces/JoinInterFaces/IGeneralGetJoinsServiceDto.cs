
using DTO.My.HighSchoolProject.WebAPI.Dto.GroupByStudentsMajorAndClass;
using DTO.My.HighSchoolProject.WebAPI.GetDtos;
using DTO.My.HighSchoolProject.WebAPI.GetDtos.GroupByStudentsSmC;
using DTO.My.HighSchoolProject.WebAPI.GetDtos.StudentJoinDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ServiceInterfaces.JoinInterFaces
{
    public interface IGeneralGetJoinsServiceDto
    {
        IQueryable<StudentJoins> GetJoins();

        List<StudentGetDayOffJoin> GetDayOffs();
    }
}
