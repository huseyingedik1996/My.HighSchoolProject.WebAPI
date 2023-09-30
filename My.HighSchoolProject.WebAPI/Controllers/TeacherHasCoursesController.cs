using DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.TeacherDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.TeacherHasCoursesDtos;
using Microsoft.AspNetCore.Mvc;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.Business.Services.CourseService;
using My.HighSchoolProject.DataAccess.Models2;

namespace My.HighSchoolProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/TeachersCourses")]
    public class TeacherHasCoursesController : ControllerBase
    {
        private readonly ITeacherHasCoursesService _service;

        public TeacherHasCoursesController(ITeacherHasCoursesService service)
        {
            _service = service;
        }

        [HttpPost("teacherCourses/create")]
        public async Task<IActionResult> Create([FromQuery] CreateTeacherHasCoursesDto createDto)
        {
            var addedEntity = await _service.Create(createDto);
            return Created(string.Empty, addedEntity);
        }

        [HttpPut("teacherCourses/update")]
        public async Task<IActionResult> UpdateDtos([FromQuery] UpdateTeacherHasCoursesDto updateDto)
        {
            var updatedMajor = await _service.UpdateDtos(updateDto);
            return Ok(updatedMajor);
        }

        [HttpGet("teacherCourses/getall")]
        public async Task<IActionResult> GetAll()
        {
            var getAll = await _service.GetAll();
            return Ok(getAll);
        }

        [HttpGet("removeTeacherCourses/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var removed = await _service.Remove(id);
            return Ok(removed);
        }

        [HttpGet("getbyTeacherCourses/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getId = await _service.GetById(id);
            return Ok(getId);
        }

        
    }
}
