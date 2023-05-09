using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Dto.Models;
using Shared.Requests;
using Utensils_Api.Database;
using Utensils_Api.Database.Models;

namespace Utensils_Api.Controllers
{
    [Route("api/events")]
    [ApiController]
    //[Authorize]
    [AllowAnonymous]
    public class EventController : ControllerBase
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public EventController(
            ApplicationDbContext context,
            IMapper mapper
        ) {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public ActionResult<EventDto> CreateEvent([FromBody] CreateEventRequest request)
        {
            User user = _context.Users.First(u => u.Id == request.UserId);

            Event eventToSave = new Event()
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                EventType = request.EventType,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Group = _mapper.Map<Group>(request.Group),
                Payments = new List<Payment>()
                {
                    new Payment()
                    {
                        Id = Guid.NewGuid(),
                        Balance = 10,
                        RecievingUser = user,
                        OwingUser = user,
                    }
                },
                Users = new List<User>() { user }
            };

            _context.Events.Add(eventToSave);
            _context.SaveChanges();

            return Ok(_mapper.Map<EventDto>(eventToSave));
        }
    }
}
