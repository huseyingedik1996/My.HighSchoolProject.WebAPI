using AutoMapper;
using DTO.My.HighSchoolProject.WebAPI.Dto.ContactDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentClassMajorsDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentDtos;
using DTO.My.HighSchoolProject.WebAPI.GetDtos.StudentJoinDtos;
using Microsoft.AspNetCore.Mvc;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.Business.ServiceInterfaces.JoinInterFaces;
using My.HighSchoolProject.DataAccess.Models2;
using System.Drawing;
using System.Text.Json.Serialization;

namespace My.HighSchoolProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/StudentsController")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IGeneralGetJoinsServiceDto _joins;

        public StudentsController(IStudentService studentService, IGeneralGetJoinsServiceDto joins)
        {
            _studentService = studentService;
            _joins = joins;
        }

        [HttpPost("student/create")]
        public async Task<IActionResult> Create([FromQuery] StudentCreateDto student)
        {
            var addedStudent = await _studentService.Create(student);

            return Created(string.Empty, addedStudent);

        }

        [HttpPut("student/update")]
        public async Task<IActionResult> Update([FromQuery] StudentUpdateDto dto)
        {
            var updatedStudent = await _studentService.UpdateDtos(dto);
            return Ok(updatedStudent);
        }

        [HttpGet("student/getall")]
        public async Task<IActionResult> GetAll()
        {
            var getAll = await _studentService.GetAll();
            return Ok(getAll);
        }

        [HttpGet("removeStudent/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var removed = await _studentService.Remove(id);
            return Ok(removed);
        }

        [HttpGet("getbyStudent/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getId = await _studentService.GetById(id);
            return Ok(getId);
        }

        [HttpGet("getJoins/getjoins")]
        public IActionResult GetJoins()
        {
            var joins = _joins.GetJoins();
            return Ok(joins);
        }
        [HttpGet("getDayOff/totalDayoff")]
        public IActionResult GetDayOffJoins()
        {
            var joins = _joins.GetDayOffs();
            return Ok(joins);
        }

    }


}

