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
    public class CursoController : ControllerBase
    {
        private ICursoBusiness _cursoBusiness;

        public CursoController(ICursoBusiness cursoBusiness)
        {
            _cursoBusiness = cursoBusiness;
        }

        [HttpGet("child/{id}")]
        [ProducesResponseType((200), Type = typeof(List<OrgUnitVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetChild(long id)

        {
            var filial = _cursoBusiness.OrgStructureChildCurso(id);
            if (filial == null) return NotFound();
            return Ok(filial);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(OrgUnitVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)

        {
            var filial = _cursoBusiness.OrgStructureCurso(id);
            if (filial == null) return NotFound();
            return Ok(filial);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(OrgUnitCreateDataVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] OrgUnitCreateDataVO uo)
        {
            if (uo == null) return BadRequest();
            return Ok(_cursoBusiness.CreateD2lCurso(uo));
        }

        [HttpPut("{id}")]
        [ProducesResponseType((200), Type = typeof(OrgUnitPropertiesVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put(long id, [FromBody] OrgUnitPropertiesVO uo)
        {
            if (uo == null) return BadRequest();
            return Ok(_cursoBusiness.UpdateD2lCurso(id,uo));
        }
    }
}
