using DTO.My.HighSchoolProject.WebAPI.GetDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ServiceInterfaces.JoinInterFaces
{
    public interface IStudentMajorClassesService
    {
        IQueryable<SampleGetJoinDto> GetJoins();
    }
}
