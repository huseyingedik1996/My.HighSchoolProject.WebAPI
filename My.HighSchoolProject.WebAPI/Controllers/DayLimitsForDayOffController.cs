using DTO.My.HighSchoolProject.WebAPI.Dto.ClassDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.DayLimitsForDayOffDtos;
using Microsoft.AspNetCore.Mvc;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.Business.Services.ClassService;

namespace My.HighSchoolProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/DayLimitsController")]
    public class DayLimitsForDayOffController : ControllerBase
    {
        private readonly IDayLimitsForDayOffService _dayLimitsForDayOffService;

        public DayLimitsForDayOffController(IDayLimitsForDayOffService dayLimitsForDayOffService)
        {
            _dayLimitsForDayOffService = dayLimitsForDayOffService;
        }

        [HttpPost("daylimit/create")]
        public async Task<IActionResult> Create([FromQuery] CreateDayLimitsForDayOffDto entity)
        {
            var addedLimit = await _dayLimitsForDayOffService.Create(entity);
            return Created(string.Empty, addedLimit);
        }

        [HttpPut("daylimit/update")]
        public async Task<IActionResult> UpdateDtos([FromQuery] UpdateDayLimitsForDayOffDtos entity)
        {
            var updatedMajor = await _dayLimitsForDayOffService.UpdateDtos(entity);
            return Ok(entity);
        }

        [HttpGet("daylimit/getall")]
        public async Task<IActionResult> GetAll()
        {
            var getAll = await _dayLimitsForDayOffService.GetAll();
            return Ok(getAll);
        }

        [HttpGet("removeDaylimit/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var removed = await _dayLimitsForDayOffService.Remove(id);
            return Ok(removed);
        }

        [HttpGet("getbyClass/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getId = await _dayLimitsForDayOffService.GetById(id);
            return Ok(getId);
        }
    }
}
