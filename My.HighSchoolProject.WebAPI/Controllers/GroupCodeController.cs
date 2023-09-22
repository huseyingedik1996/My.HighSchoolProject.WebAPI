using DTO.My.HighSchoolProject.WebAPI.Dto.GroupCodeDtos;
using Microsoft.AspNetCore.Mvc;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.DataAccess.Models;

namespace My.HighSchoolProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/GroupCodeController")]
    public class GroupCodeController : ControllerBase
    {
        private readonly IGroupCodeService _groupCodeService;

        public GroupCodeController(IGroupCodeService groupCodeService)
        {
            _groupCodeService = groupCodeService;
        }

        [HttpPost("groupCode/create")]
        public async Task<IActionResult> Create([FromQuery]CreateGroupCodeDto dto)
        {
            var createdCode = await _groupCodeService.Create(dto);
            return Created(string.Empty, createdCode);
        }

        [HttpPut("groupCode/update")]
        public async Task<IActionResult> Update([FromQuery] UpdateGroupCodeDto dto)
        {
            var updatedCode = await _groupCodeService.UpdateDtos(dto);
            return Ok(updatedCode);
        }

        [HttpGet("groupCode/getAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _groupCodeService.GetAll();
            return Ok(data);    
        }

        [HttpGet("groupCode/getWithcode")]
        public async Task<IActionResult> GetByGroupCode(string dto)
        {
            var getCode = await _groupCodeService.GetByGroupCode(dto);
            return Ok(getCode);
        }

        [HttpGet("groupCodeRemove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var removeCode = await _groupCodeService.Remove(id);  
            return Ok(removeCode);
        }
        

    }
}
