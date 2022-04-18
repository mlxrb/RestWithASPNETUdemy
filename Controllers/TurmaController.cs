


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Data.VO.D2lVO;
using RestWithASPNETUdemy.Hypermedia.Filters;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private ITurmaBusiness _turmaBusiness;

        public TurmaController(ITurmaBusiness turmaBusiness)
        {
            _turmaBusiness = turmaBusiness;
        }

        [HttpGet("child/{id}")]
        [ProducesResponseType((200), Type = typeof(List<OrgUnitVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetChild(long id)

        {
            var filial = _turmaBusiness.OrgStructureChildTurma(id);
            if (filial == null) return NotFound();
            return Ok(filial);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(CourseTemplateVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)

        {
            var filial = _turmaBusiness.OrgStructureTurma(id);
            if (filial == null) return NotFound();
            return Ok(filial);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(CreateCourseTemplateVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] CreateCourseTemplateVO uo)
        {
            if (uo == null) return BadRequest();
            return Ok(_turmaBusiness.CreateD2lTurma(uo));
        }

        [HttpPut("{id}")]
        [ProducesResponseType((200), Type = typeof(CourseTemplateInfoVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put(long id, [FromBody] CourseTemplateInfoVO uo)
        {
            if (uo == null) return BadRequest();
            return Ok(_turmaBusiness.UpdateD2lTurma(id,uo));
        }
    }
}
