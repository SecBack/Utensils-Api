using Microsoft.AspNetCore.Mvc;
using Utensils_Api.Database;

namespace Utensils_Api.Controllers
{
    [Route("api/groups")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GroupController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<int> Get()
        {
            // get all groups with relations
            _context
        }
    }
}
