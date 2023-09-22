using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.SemesterDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ServiceInterfaces
{
    public interface ISemesterService
    {
        Task<IResponse<List<SemesterListDto>>> GetAll();

        Task<IResponse<SemesterCreateDto>> Create(SemesterCreateDto semesterCreateDto);

        Task<IResponse<SemesterListDto>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<List<SemesterUpdateDto>>> UpdateDtos(SemesterUpdateDto semesterUpdateDto);
    }
}
