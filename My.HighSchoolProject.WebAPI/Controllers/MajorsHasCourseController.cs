using DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.MajorHasCourseDto;
using Microsoft.AspNetCore.Mvc;
using My.HighSchoolProject.Business.ServiceInterfaces;

namespace My.HighSchoolProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/MajorHasCourseControlller")]
    public class MajorsHasCourseController : ControllerBase
    {
        private readonly IMajorsHasCourseService _service;

        public MajorsHasCourseController(IMajorsHasCourseService service)
        {
            _service = service;
        }

        [HttpPost("MajorHasCourse/create")]
        public async Task<IActionResult> Create([FromQuery] CreateMajorHasCourseDto createDto)
        {
            var addedEntity = await _service.Create(createDto);
            return Created(string.Empty, addedEntity);
        }

        [HttpPut("MajorHasCourse/update")]
        public async Task<IActionResult> UpdateDtos([FromQuery] UpdateMajorHasCouseDto updateDto)
        {
            var updatedMajor = await _service.UpdateDtos(updateDto);
            return Ok(updateDto);
        }

        [HttpGet("MajorHasCourse/getall")]
        public async Task<IActionResult> GetAll()
        {
            var getAll = await _service.GetAll();
            return Ok(getAll);
        }

        [HttpGet("MajorHasCourseRemove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _service.Remove(id);
            return Ok();
        }

        [HttpGet("MajorHasCourseGetBy/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getId = await _service.GetById(id);
            return Ok(getId);
        }
    }
}
