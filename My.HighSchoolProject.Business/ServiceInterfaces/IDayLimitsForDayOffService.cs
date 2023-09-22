using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.DayLimitsForDayOffDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ServiceInterfaces
{
    public interface IDayLimitsForDayOffService
    {
        Task<IResponse<List<ListDayLimitsForDayOffDtos>>> GetAll();

        Task<IResponse<CreateDayLimitsForDayOffDto>> Create(CreateDayLimitsForDayOffDto createDayLimits);

        Task<IResponse<ListDayLimitsForDayOffDtos>> GetById(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<List<UpdateDayLimitsForDayOffDtos>>> UpdateDtos(UpdateDayLimitsForDayOffDtos updateDayLimits);
    }
}
