using DTO.My.HighSchoolProject.WebAPI.Dto.MajorDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.SemesterDtos;
using Microsoft.AspNetCore.Mvc;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.Business.Services.MajorService;

namespace My.HighSchoolProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/SemesterController")]
    public class SemesterController : ControllerBase
    {
        private readonly ISemesterService _semesterService;

        public SemesterController(ISemesterService semesterService)
        {
            _semesterService = semesterService;
        }

        [HttpPost("semester/create")]
        public async Task<IActionResult> Create([FromQuery] SemesterCreateDto semesterCreateDto)
        {
            var addedSemester = await _semesterService.Create(semesterCreateDto);
            return Created(string.Empty, addedSemester);
        }

        [HttpPut("semester/update")]
        public async Task<IActionResult> UpdateDtos([FromQuery] SemesterUpdateDto semesterUpdateDto)
        {
            var updatedSemester = await _semesterService.UpdateDtos(semesterUpdateDto);
            return Ok(updatedSemester);
        }

        [HttpGet("semester/getall")]
        public async Task<IActionResult> GetAll()
        {
            var getAll = await _semesterService.GetAll();
            return Ok(getAll);
        }

        [HttpGet("removeSemester/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var removed = await _semesterService.Remove(id);
            return Ok(removed);
        }

        [HttpGet("getbySemester/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getId = await _semesterService.GetById(id);
            return Ok(getId);
        }
    }
}
