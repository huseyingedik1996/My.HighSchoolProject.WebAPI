using DTO.My.HighSchoolProject.WebAPI.Dto.TeacherDtos;
using Microsoft.AspNetCore.Mvc;
using My.HighSchoolProject.Business.ServiceInterfaces;

namespace My.HighSchoolProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/TeacherController")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _service;

        public TeacherController(ITeacherService service)
        {
            _service = service;
        }

        [HttpPost("Teacher/create")]
        public async Task<IActionResult> Create([FromQuery] CreateTeacherDto createDto)
        {
            var addedEntity = await _service.Create(createDto);
            return Created(string.Empty, addedEntity);
        }

        [HttpPut("Teacher/update")]
        public async Task<IActionResult> UpdateDtos([FromQuery] UpdateTeacherDto updateDto)
        {
            var updatedMajor = await _service.UpdateDtos(updateDto);
            return Ok(updateDto);
        }

        [HttpGet("Teacher/getall")]
        public async Task<IActionResult> GetAll()
        {
            var getAll = await _service.GetAll();
            return Ok(getAll);
        }

        [HttpGet("removeTeacher/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var removed = await _service.Remove(id);
            return Ok(removed);
        }

        [HttpGet("getbyTeacher/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getId = await _service.GetById(id);
            return Ok(getId);
        }
    }
}
