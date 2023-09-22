using DTO.My.HighSchoolProject.WebAPI.Dto.MajorDtos;
using Microsoft.AspNetCore.Mvc;
using My.HighSchoolProject.Business.ServiceInterfaces;

namespace My.HighSchoolProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/MajorController")]
    public class MajorController : ControllerBase
    {
        private readonly IMajorService _majorService;

        public MajorController(IMajorService majorService)
        {
            _majorService = majorService;
        }

        [HttpPost("major/create")]
        public async Task<IActionResult> Create([FromQuery]MajorCreateDto majorCreateDto)
        {
            var addedMajor = await _majorService.Create(majorCreateDto);
            return Created(string.Empty, addedMajor);
        }

        [HttpPut("major/update")]
        public async Task<IActionResult> UpdateDtos([FromQuery]MajorUpdateDto majorUpdateDto)
        {
            var updatedMajor = await _majorService.UpdateDtos(majorUpdateDto);
            return Ok(updatedMajor);
        }

        [HttpGet("major/getall")]
        public async Task<IActionResult> GetAll()
        {
            var getAll = await _majorService.GetAll();
            return Ok(getAll);
        }

        [HttpGet("removeMajor/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var removed = await _majorService.Remove(id);
            return Ok(removed);
        }

        [HttpGet("getbyMajor/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getId = await _majorService.GetById(id);
            return Ok(getId);
        }
    }
}
