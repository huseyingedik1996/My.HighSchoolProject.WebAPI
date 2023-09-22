using DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.GeneralOfficerDtos;
using Microsoft.AspNetCore.Mvc;
using My.HighSchoolProject.Business.ServiceInterfaces;

namespace My.HighSchoolProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/GeneralOfficerController")]
    public class GeneralOFficerController : ControllerBase
    {
        private readonly IGeneralOfficerService _service;

        public GeneralOFficerController(IGeneralOfficerService service)
        {
            _service = service;
        }

        [HttpPost("generalOfficer/create")]
        public async Task<IActionResult> Create([FromQuery] CreateGeneralOfficerDto createDto)
        {
            var addedEntity = await _service.Create(createDto);
            return Created(string.Empty, addedEntity);
        }

        [HttpPut("generalOfficer/update")]
        public async Task<IActionResult> UpdateDtos([FromQuery] UpdateGeneralOfficerDto updateDto)
        {
            var updatedMajor = await _service.UpdateDtos(updateDto);
            return Ok(updateDto);
        }

        [HttpGet("generalOfficer/getall")]
        public async Task<IActionResult> GetAll()
        {
            var getAll = await _service.GetAll();
            return Ok(getAll);
        }

        [HttpGet("removeGeneralofficer/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var removed = await _service.Remove(id);
            return Ok(removed);
        }

        [HttpGet("getbyOfficer/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getId = await _service.GetById(id);
            return Ok(getId);
        }
    }
}
