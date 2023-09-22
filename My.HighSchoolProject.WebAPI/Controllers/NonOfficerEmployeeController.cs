using DTO.My.HighSchoolProject.WebAPI.Dto.NonOfficerEmployeeDtos;
using Microsoft.AspNetCore.Mvc;
using My.HighSchoolProject.Business.ServiceInterfaces;

namespace My.HighSchoolProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/NonOfficerEmployee")]
    public class NonOfficerEmployeeController : ControllerBase
    {
        private readonly INonOfficerEmployeeService _service;

        public NonOfficerEmployeeController(INonOfficerEmployeeService service)
        {
            _service = service;
        }

        [HttpPost("NonOfficerEmployee/create")]
        public async Task<IActionResult> Create([FromQuery] CreateNonOfficerEmployee createDto)
        {
            var addedEntity = await _service.Create(createDto);
            return Created(string.Empty, addedEntity);
        }

        [HttpPut("NonOfficerEmployee/update")]
        public async Task<IActionResult> UpdateDtos([FromQuery] UpdateNonOfficerEmployeeDto updateDto)
        {
            var updatedMajor = await _service.UpdateDtos(updateDto);
            return Ok(updateDto);
        }

        [HttpGet("NonOfficerEmployee/getall")]
        public async Task<IActionResult> GetAll()
        {
            var getAll = await _service.GetAll();
            return Ok(getAll);
        }

        [HttpGet("removeNonOfficerEmployee/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var removed = await _service.Remove(id);
            return Ok(removed);
        }

        [HttpGet("getbyNonOfficerEmployee/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getId = await _service.GetById(id);
            return Ok(getId);
        }
    }
}
