using DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomDtos;
using Microsoft.AspNetCore.Mvc;
using My.HighSchoolProject.Business.ServiceInterfaces;
using MySqlX.XDevAPI.CRUD;

namespace My.HighSchoolProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/ClassroomController")]
    public class ClassroomController : ControllerBase
    {
        private readonly IClassroomService _classroom;

        public ClassroomController(IClassroomService classroom)
        {
            _classroom = classroom;
        }

        [HttpPost("Classroom/Create")]
        public async Task<IActionResult> Create([FromQuery] CreateClassroomDto createClassroom)
        {
            var createdClassroom = await _classroom.Create(createClassroom);
            return Created(string.Empty, createClassroom);
        }

        [HttpPost("Classroom/Update")]
        public async Task<IActionResult> UpdateDtos(UpdateClassroomDto updateClassroom)
        {
            var updatedClassroom = await _classroom.UpdateDtos(updateClassroom);
            return Ok(updatedClassroom);
        }

        [HttpGet("ClassroomGet/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getById =  await _classroom.GetById(id);
            return Ok(getById);
        }

        [HttpGet("Classroom/Getall")]
        public async Task<IActionResult> GetAll()
        {
            var getAll = await _classroom.GetAll();
            return Ok(getAll);
        }

        [HttpGet("Classroom/Remove{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var removedData = await _classroom.Remove(id);
            return Ok(removedData);
        }
    }
}
