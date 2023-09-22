using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.NonOfficerEmployeeDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.TeacherDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ServiceInterfaces
{
    public interface ITeacherService
    {
        Task<IResponse<List<ListTeacherDto>>> GetAll();

        Task<IResponse<CreateTeacherDto>> Create(CreateTeacherDto createDto);

        Task<IResponse<ListTeacherDto>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<List<UpdateTeacherDto>>> UpdateDtos(UpdateTeacherDto updateDto);
    }
}
