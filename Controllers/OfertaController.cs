


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
    public class OfertaController : ControllerBase
    {
        private IOfertaBusiness _ofertaBusiness;

        public OfertaController(IOfertaBusiness ofertaBusiness)
        {
            _ofertaBusiness = ofertaBusiness;
        }

        [HttpGet("ancestors/{id}")]
        [ProducesResponseType((200), Type = typeof(List<OrgUnitVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetAncestors(long id)

        {
            var filial = _ofertaBusiness.OrgStructureAncestorsOferta(id);
            if (filial == null) return NotFound();
            return Ok(filial);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(OfertaVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)

        {
            var filial = _ofertaBusiness.getOfertas(id);
            if (filial == null) return NotFound();
            return Ok(filial);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(OfertaVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] OfertaVOPost uo)
        {
            if (uo == null) return BadRequest();
            return Ok(_ofertaBusiness.CreateD2lOferta(uo));
        }

        [HttpPut("{id}")]
        [ProducesResponseType((200), Type = typeof(OfertaVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put(long id, [FromBody] OfertaVO uo)
        {
            if (uo == null) return BadRequest();
            return Ok(_ofertaBusiness.UpdateD2lOferta(id,uo));
        }
    }
}
