using DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.CourseHoursByMajorClassDto;
using Microsoft.AspNetCore.Mvc;
using My.HighSchoolProject.Business.ServiceInterfaces;

namespace My.HighSchoolProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/MajorCourseHours")]
    public class CourseHoursByMajorClassController : ControllerBase
    {
        private readonly ICourseHoursByMajorClassService _service;

        public CourseHoursByMajorClassController(ICourseHoursByMajorClassService service)
        {
            _service = service;
        }

        [HttpPost("courseHour/create")]
        public async Task<IActionResult> Create([FromQuery] CreateCourseHoursByMajorClassDto createDto)
        {
            var addedEntity = await _service.Create(createDto);
            return Created(string.Empty, addedEntity);
        }

        [HttpPut("courseHour/update")]
        public async Task<IActionResult> UpdateDtos([FromQuery] UpdateCourseHoursByMajorClassDto updateDto)
        {
            var updatedMajor = await _service.UpdateDtos(updateDto);
            return Ok(updateDto);
        }

        [HttpGet("courseHour/getall")]
        public async Task<IActionResult> GetAll()
        {
            var getAll = await _service.GetAll();
            return Ok(getAll);
        }

        [HttpGet("removecourseHour/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var removed = await _service.Remove(id);
            return Ok(removed);
        }

        [HttpGet("getBycourseHour/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getId = await _service.GetById(id);
            return Ok(getId);
        }
    }
}
