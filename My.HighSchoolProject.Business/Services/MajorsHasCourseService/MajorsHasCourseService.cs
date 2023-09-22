using AutoMapper;
using Common.My.HighSchoolProject.WebAPI.Response;
using DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.MajorHasCourseDto;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.DataAccess.Models;
using My.HighSchoolProject.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.Services.MajorsHasCourseDto
{
    public class MajorsHasCourseService : IMajorsHasCourseService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        

        public MajorsHasCourseService(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<CreateMajorHasCourseDto> Create(CreateMajorHasCourseDto createMajorHas)
        {
            await _uow.GetRepository<MajorsHasCourse>().Create(_mapper.Map<MajorsHasCourse>(createMajorHas));
            return createMajorHas;
        }

        public async Task<List<ListMajorHasCourseDto>> GetAll()
        {
            var data = _mapper.Map<ListMajorHasCourseDto>(await _uow.GetRepository<MajorsHasCourse>().GetAll());
            return new List<ListMajorHasCourseDto> { data };
        }

        public async Task<ListMajorHasCourseDto> GetById(int id)
        {
            var data = _mapper.Map<ListMajorHasCourseDto>(await _uow.GetRepository<MajorsHasCourse>().GetByFilter(x => x.IdMajorsCourses ==  id));
            return data;
        }

        public async Task Remove(int id)
        {
            var removedEntry = await _uow.GetRepository<MajorsHasCourse>().GetByFilter(x => x.IdMajorsCourses == id);
            if (removedEntry != null)
            {
                _uow.GetRepository<MajorsHasCourse>().Remove(removedEntry);
                await _uow.SaveChanges();  
            }
        }

        public async Task<List<UpdateMajorHasCouseDto>> UpdateDtos(UpdateMajorHasCouseDto updateMajorHas)
        {
            var updatedEntity = await _uow.GetRepository<UpdateMajorHasCouseDto>().GetById(updateMajorHas.IdMajorsCourses);
            if (updatedEntity != null)
            {
                _uow.GetRepository<UpdateMajorHasCouseDto>().Update(_mapper.Map<UpdateMajorHasCouseDto>(updateMajorHas), updatedEntity);
                await _uow.SaveChanges();
                return new List<UpdateMajorHasCouseDto> { updatedEntity };
            }
            return new List<UpdateMajorHasCouseDto>();
        }
    }
}
