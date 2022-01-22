using ANAF.API;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo.Api.Controllers
{
    [ApiController]
    [Route("demo")]
    public class DemoController : ControllerBase
    {
        private readonly IAnafService _anafService;

        public DemoController(IAnafService anafService)
        {
            _anafService = anafService;
        }

        [HttpGet("{cui}")]
        public async Task<IActionResult> Get([FromRoute] string cui)
        {
            try
            {
                var result = await _anafService.SearchCompany(cui);
                return Ok(result);
            }
            catch (AnafException)
            {
                throw;
            }
        }
    }
}