using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.ContactDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentClassMajorsDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentDtos;
using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using My.HighSchoolProject.DataAccess.Models2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ServiceInterfaces
{
    public interface IStudentService
    {
        Task<IResponse<List<StudentListDtos>>> GetAll();

        Task<IResponse<StudentCreateDto>> Create(StudentCreateDto studentCreateDto);
        
        Task<IResponse<StudentListDtos>> GetById(int id);

        Task<IResponse>Remove(int id);

        Task<IResponse<List<StudentUpdateDto>>> UpdateDtos(StudentUpdateDto studentUpdateDto);

    }
}
