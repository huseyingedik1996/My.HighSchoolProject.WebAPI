using DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassDtos;
using Microsoft.AspNetCore.Mvc;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.Business.Services.ClassService;

namespace My.HighSchoolProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/BranchController")]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _service;

        public BranchController(IBranchService service)
        {
            _service = service;
        }

    
        [HttpPost("branch/create")]
        public async Task<IActionResult> Create([FromQuery] CreateBranchDtos createDto)
        {
            var addedEntity = await _service.Create(createDto);
            return Created(string.Empty, addedEntity);
        }

        [HttpPut("branch/update")]
        public async Task<IActionResult> UpdateDtos([FromQuery] UpdateBranchDtos updateDto)
        {
            var updatedMajor = await _service.UpdateDtos(updateDto);
            return Ok(updatedMajor);
        }

        [HttpGet("branch/getall")]
        public async Task<IActionResult> GetAll()
        {
            var getAll = await _service.GetAll();
            return Ok(getAll);
        }

        [HttpGet("removeBranch/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var removed = await _service.Remove(id);
            return Ok(removed);
        }

        [HttpGet("getbyBranch/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getId = await _service.GetById(id);
            return Ok(getId);
        }
    }
}
