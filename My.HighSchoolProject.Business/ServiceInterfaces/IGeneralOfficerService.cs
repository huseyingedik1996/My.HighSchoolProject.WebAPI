using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.GeneralOfficerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ServiceInterfaces
{
    public interface IGeneralOfficerService
    {
        Task<IResponse<List<ListGeneralOfficerDto>>> GetAll();

        Task<IResponse<CreateGeneralOfficerDto>> Create(CreateGeneralOfficerDto createGeneralOff);

        Task<IResponse<ListGeneralOfficerDto>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<List<UpdateGeneralOfficerDto>>> UpdateDtos(UpdateGeneralOfficerDto updateGeneralOff);
    }
}
