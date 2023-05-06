using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Utensils_Api.Controllers
{
    [Route("api/events")]
    [ApiController]
    [Authorize]
    public class EventController : ControllerBase
    {
        [HttpGet]
        public ActionResult<int> Get()
        {
            return 5;
        }
    }
}
