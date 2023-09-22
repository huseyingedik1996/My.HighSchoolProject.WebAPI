using DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomsGroupDtos;
using Microsoft.AspNetCore.Mvc;
using My.HighSchoolProject.Business.ServiceInterfaces;

namespace My.HighSchoolProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/ClassroomsgroupController")]
    public class ClassroomsGroupController : ControllerBase
    {
        private readonly IClassroomsGroupService _service;

        public ClassroomsGroupController(IClassroomsGroupService service)
        {
            _service = service;
        }

        [HttpPost("classroomsGroup/create")]
        public async Task<IActionResult> Create([FromQuery] CreateClassroomsGroupDto createDto)
        {
            var addedEntity = await _service.Create(createDto);
            return Created(string.Empty, addedEntity);
        }

        [HttpPut("classroomsGroup/update")]
        public async Task<IActionResult> UpdateDtos([FromQuery] UpdateClassroomsGroupDto updateDto)
        {
            var updatedMajor = await _service.UpdateDtos(updateDto);
            return Ok(updateDto);
        }

        [HttpGet("classroomsGroup/getall")]
        public async Task<IActionResult> GetAll()
        {
            var getAll = await _service.GetAll();
            return Ok(getAll);
        }

        [HttpGet("removeGroup/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var removed = await _service.Remove(id);
            return Ok(removed);
        }

        [HttpGet("getByClassGroup/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getId = await _service.GetById(id);
            return Ok(getId);
        }
    }
}
