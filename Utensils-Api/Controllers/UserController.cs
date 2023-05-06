using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Dto.Models;
using Utensils_Api.Database;
using Utensils_Api.Database.Models;

namespace Utensils_Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    //[Authorize]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private ApplicationDbContext _context { get; set; }
        private readonly IMapper _mapper;

        public UserController(
            ApplicationDbContext applicationDbContext,
            IMapper mapper
        ) {
            _context = applicationDbContext;
            _mapper = mapper;

        }

        [Route("{id}/details")]
        [HttpGet]
        public ActionResult<UserDto> GetUserDetails(Guid id)
        {
            User? user = _context.Users.Include(u => u.Events)
                .Include(u => u.Groups)
                .Include(u => u.OwedPayments)
                .Include(u => u.ReceivingPayments)
                .FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserDto>(user));
        }
    }
}
