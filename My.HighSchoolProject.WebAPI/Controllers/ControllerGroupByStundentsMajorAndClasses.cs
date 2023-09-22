using DTO.My.HighSchoolProject.WebAPI.Dto.GroupByStudentsMajorAndClass;
using Microsoft.AspNetCore.Mvc;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.Business.ServiceInterfaces.JoinInterFaces;

namespace My.HighSchoolProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/GrupBySmC")]
    public class ControllerGroupByStundentsMajorAndClasses : ControllerBase
    {
        private readonly IGroupByStundentsMajorAndClasses _groupSmC;
     
        private readonly IStudentMajorClassesService _getGroupBy;

        public ControllerGroupByStundentsMajorAndClasses(IGroupByStundentsMajorAndClasses groupSmC, IStudentMajorClassesService getGroupBy)
        {
            _groupSmC = groupSmC;
            
            _getGroupBy = getGroupBy;
        }
        [HttpPost("groupSmC/create")]
        public async Task<IActionResult> Create([FromQuery] CreateGroupByStudentsMajorAndClass createGroupSmC)
        {
            var addedSmC = await _groupSmC.Create(createGroupSmC);
            return Created(string.Empty, addedSmC);
        }

        [HttpPost("groupSmC/update")]
        public async Task<IActionResult> UpdateDtos([FromQuery]UpdateGroupByStudentsMajorAndClass updated)
        {
            var updatedEntity = await _groupSmC.UpdateDtos(updated);
            return Ok(updatedEntity);
        }
        [HttpGet("groupSmC/remove")]
        public async Task<IActionResult> Remove(int id)
        {
            var removedEntity = await _groupSmC.Remove(id);
            return Ok(removedEntity);
        }

        [HttpGet("getJoin/GetJoins")]
        public IActionResult GetJoin()
        {
            var results = _getGroupBy.GetJoins();
            return Ok(results);
        }
    }
}
