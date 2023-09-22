using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.ContactDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.MajorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ServiceInterfaces
{
    public interface IMajorService
    {
        Task<IResponse<List<MajorListDto>>> GetAll();

        Task<IResponse<MajorCreateDto>> Create(MajorCreateDto majorCreateDto);

        Task<IResponse<MajorListDto>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<List<MajorUpdateDto>>> UpdateDtos(MajorUpdateDto majorUpdateDto);
    }
}
