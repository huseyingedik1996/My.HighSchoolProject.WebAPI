using DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.ResponsibilityDtos;
using Microsoft.AspNetCore.Mvc;
using My.HighSchoolProject.Business.ServiceInterfaces;

namespace My.HighSchoolProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/ResponsibilityController")]
    public class ResponsibilityController : ControllerBase
    {
        private readonly IResponsibilityService _service;

        public ResponsibilityController(IResponsibilityService service)
        {
            _service = service;
        }

        [HttpPost("responsibility/create")]
        public async Task<IActionResult> Create([FromQuery] CreateResponsibilityDto createDto)
        {
            var addedEntity = await _service.Create(createDto);
            return Created(string.Empty, addedEntity);
        }

        [HttpPut("responsibility/update")]
        public async Task<IActionResult> UpdateDtos([FromQuery] UpdateResponsibilityDto updateDto)
        {
            var updatedMajor = await _service.UpdateDtos(updateDto);
            return Ok(updateDto);
        }

        [HttpGet("responsibility/getall")]
        public async Task<IActionResult> GetAll()
        {
            var getAll = await _service.GetAll();
            return Ok(getAll);
        }

        [HttpGet("removeResponsibility/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var removed = await _service.Remove(id);
            return Ok(removed);
        }

        [HttpGet("getByresponsibility/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getId = await _service.GetById(id);
            return Ok(getId);
        }
    }
}
