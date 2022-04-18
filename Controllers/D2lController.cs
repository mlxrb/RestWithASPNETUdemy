using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;


namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [Authorize("Bearer")]
    [ApiController]
    public class D2lController : ControllerBase
    {
        private IWhoAmUserBusiness _whoBusiness;

        public D2lController(IWhoAmUserBusiness whoBusiness)
        {
            _whoBusiness = whoBusiness;
        }

        [HttpGet]           
        public IActionResult Get()
        {
            var who = _whoBusiness.ExecuteService("/users/whoami");
            if (who == null) return NotFound();
            return Ok(who);
        }
    }
}
