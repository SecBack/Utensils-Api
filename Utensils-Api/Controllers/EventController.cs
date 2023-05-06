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
            Event eventToSave = new Event()
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                EventType = request.EventType,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Group = _mapper.Map<Group>(request.Group)
            };

            _context.Events.Add(eventToSave);
            _context.SaveChanges();

            return Ok(_mapper.Map<EventDto>(eventToSave));
        }
    }
}
