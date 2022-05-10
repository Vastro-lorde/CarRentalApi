using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalCarApi.Middlewares.Filters;

namespace RentalCarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost]
        [ValidateModel]
        public IActionResult GetAll(GetAllUser getAll)
        {
            return Ok();
        }
    }
}
