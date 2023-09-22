using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.MajorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ServiceInterfaces
{
    public interface IClassService
    {
        Task<IResponse<List<ClassListDto>>> GetAll();

        Task<IResponse<ClassCreateDto>> Create(ClassCreateDto classCreateDto);

        Task<IResponse<ClassListDto>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<List<ClassUpdateDto>>> UpdateDtos(ClassUpdateDto classUpdateDto);
    }
}
