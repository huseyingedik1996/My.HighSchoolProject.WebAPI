using DTO.My.HighSchoolProject.WebAPI.Dto.ClassDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.MajorDtos;
using Microsoft.AspNetCore.Mvc;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.Business.Services.MajorService;

namespace My.HighSchoolProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/ClassController")]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpPost("class/create")]
        public async Task<IActionResult> Create([FromQuery] ClassCreateDto classCreateDto)
        {
            var addedClass = await _classService.Create(classCreateDto);
            return Created(string.Empty, addedClass);
        }

        [HttpPut("class/update")]
        public async Task<IActionResult> UpdateDtos([FromQuery] ClassUpdateDto classUpdateDto)
        {
            var updatedMajor = await _classService.UpdateDtos(classUpdateDto);
            return Ok(classUpdateDto);
        }

        [HttpGet("class/getall")]
        public async Task<IActionResult> GetAll()
        {
            var getAll = await _classService.GetAll();
            return Ok(getAll);
        }

        [HttpGet("removeClass/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var removed = await _classService.Remove(id);
            return Ok(removed);
        }

        [HttpGet("getbyClass/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getId = await _classService.GetById(id);
            return Ok(getId);
        }
    }
}
