using DTO.My.HighSchoolProject.WebAPI.Dto.CourseShcedulesDtos;
using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace My.HighSchoolProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/CourseScheduleController")]
    public class CourseScheduleController : ControllerBase
    {
        private readonly IDtoCourseSchedule _service;

        public CourseScheduleController(IDtoCourseSchedule service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Create([FromQuery]CreateCourseSchedulesDto courseSchedulesDto)
        {
            var addedEntity = await _service.Create(courseSchedulesDto);
            return Created(string.Empty, addedEntity);
        }
    }
}
