using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Utensils_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        [HttpGet]
        public ActionResult<int> GetT()
        {
            return 5;
        }
    }
}
