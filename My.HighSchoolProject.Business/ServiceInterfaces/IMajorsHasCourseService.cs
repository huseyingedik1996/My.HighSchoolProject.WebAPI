using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.MajorHasCourseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.ServiceInterfaces
{
    public interface IMajorsHasCourseService
    {
        Task<List<ListMajorHasCourseDto>> GetAll();

        Task<CreateMajorHasCourseDto> Create(CreateMajorHasCourseDto createMajorHas);

        Task<ListMajorHasCourseDto> GetById(int id);

        Task Remove(int id);

        Task<List<UpdateMajorHasCouseDto>> UpdateDtos(UpdateMajorHasCouseDto updateMajorHas);
    }
}
