using DTO.My.HighSchoolProject.WebAPI.Dto.ClassDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentDayOffDtos;
using Microsoft.AspNetCore.Mvc;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.Business.Services.ClassService;

namespace My.HighSchoolProject.WebAPI.Controllers
{
    public class StudentDayOffController : ControllerBase
    {
        private readonly IStudentDayOffService _dayoffService;

        public StudentDayOffController(IStudentDayOffService dayoffService)
        {
            _dayoffService = dayoffService;
        }

        [HttpPost("dayOff/create")]
        public async Task<IActionResult> Create([FromQuery]CreateStudentDayOffDto dayOffDto)
        {
            var addedDayoff = await _dayoffService.Create(dayOffDto);
            return Created(string.Empty, addedDayoff);
        }

        [HttpPut("dayOff/update")]
        public async Task<IActionResult> UpdateDtos([FromQuery] UpdateStudentDayOfDto dayOfDto)
        {
            var updatedDayoff = await _dayoffService.UpdateDtos(dayOfDto);
            return Ok(updatedDayoff);
        }

        [HttpGet("dayOff/getall")]
        public async Task<IActionResult> GetAll()
        {
            var getAll = await _dayoffService.GetAll();
            return Ok(getAll);
        }

        [HttpGet("removeDayoff/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var removed = await _dayoffService.Remove(id);
            return Ok(removed);
        }

        [HttpGet("getbyDayOff/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getId = await _dayoffService.GetById(id);
            return Ok(getId);
        }
    }
}
