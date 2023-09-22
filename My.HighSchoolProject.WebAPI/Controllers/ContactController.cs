using AutoMapper;
using DTO.My.HighSchoolProject.WebAPI.Dto.ContactDtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.Business.Services.StudentService;
using My.HighSchoolProject.DataAccess.UnitOfWork;

namespace My.HighSchoolProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/ContactController")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _controlService;

        public ContactController(IContactService controlService)
        {
            _controlService = controlService;
        }

        [HttpPost("create/contact")]
        public async Task<IActionResult> Create([FromQuery] ContactCreateDtos contact)
        {
            var addedContract = await _controlService.Create(contact);
            return Created(string.Empty, addedContract);
        }

        [HttpPut("update/contact")]
        public async Task<IActionResult> UpdateDtos([FromQuery] ContactUpdateDtos contact)
        {
            var updatedContact = await _controlService.UpdateDtos(contact);
            return Ok(updatedContact);
        }

        [HttpGet("getallcontact")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _controlService.GetAll();
            return Ok(data);
        }

        [HttpGet("getbyContact/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _controlService.GetById(id);
            return Ok(data);
        }

        [HttpGet("removeContact/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var removedContact = await _controlService.Remove(id);
            return Ok(removedContact);
        }
    }
}
