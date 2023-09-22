using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentDayOffDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ServiceInterfaces
{
    public interface IStudentDayOffService
    {
        Task<IResponse<List<ListStudentDayOffDto>>> GetAll();

        Task<IResponse<CreateStudentDayOffDto>> Create(CreateStudentDayOffDto createDayOff);

        Task<IResponse<ListStudentDayOffDto>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<List<UpdateStudentDayOfDto>>> UpdateDtos(UpdateStudentDayOfDto updateDayOff);
    }
}
