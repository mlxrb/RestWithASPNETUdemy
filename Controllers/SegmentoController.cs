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
    public class SegmentoController : ControllerBase
    {
        private ISegmentoBusiness _segmentoBusiness;

        public SegmentoController(ISegmentoBusiness segmentoBusiness)
        {
            _segmentoBusiness = segmentoBusiness;
        }

        [HttpGet("child/{id}")]
        [ProducesResponseType((200), Type = typeof(List<OrgUnitVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetChild(long id)

        {
            var filial = _segmentoBusiness.OrgStructureChildSeg(id);
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
            var filial = _segmentoBusiness.OrgStructureSeg(id);
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
            return Ok(_segmentoBusiness.CreateD2lSeg(uo));
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
            return Ok(_segmentoBusiness.UpdateD2lSeg(id,uo));
        }
    }
}
