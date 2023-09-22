using DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomAndCourseDto;
using Microsoft.AspNetCore.Mvc;
using My.HighSchoolProject.Business.ServiceInterfaces;

namespace My.HighSchoolProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/ClassroomCourseController")]
    public class ClassroomAndCourseController : ControllerBase
    {
        private readonly IClassroomAndGroupService _service;

        public ClassroomAndCourseController(IClassroomAndGroupService service)
        {
            _service = service;
        }

        [HttpPost("classroomCourse/create")]
        public async Task<IActionResult> Create([FromQuery] CreateClassroomAndCourseDto createDto)
        {
            var addedEntity = await _service.Create(createDto);
            return Created(string.Empty, addedEntity);
        }

        [HttpPut("classroomCourse/update")]
        public async Task<IActionResult> UpdateDtos([FromQuery] UpdateClassroomAndCourseDto updateDto)
        {
            var updatedMajor = await _service.UpdateDtos(updateDto);
            return Ok(updateDto);
        }

        [HttpGet("classroomCourse/getall")]
        public async Task<IActionResult> GetAll()
        {
            var getAll = await _service.GetAll();
            return Ok(getAll);
        }

        [HttpGet("removeThat/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var removed = await _service.Remove(id);
            return Ok(removed);
        }

        [HttpGet("GetThat/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getId = await _service.GetById(id);
            return Ok(getId);
        }
    }
}
