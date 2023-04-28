using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dto.Models;
using Shared.Requests;
using Utensils_Api.Database;
using Utensils_Api.Database.Models;

namespace Utensils_Api.Controllers
{
    [Route("api/groups")]
    [ApiController]
    [Authorize]
    public class GroupController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GroupController(
            ApplicationDbContext context,
            IMapper mapper
        ) {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<GroupDto>> GetAllGroups()
        {
            List<Group> groups = _context.Groups.ToList();

            return _mapper.Map<List<GroupDto>>(groups);
        }

        [HttpPost]
        public ActionResult<GroupDto> CreateGroup([FromBody] CreateGroupRequest createGroupRequest)
        {
            Group group = new Group()
            {
                Id = Guid.NewGuid(),
                Name = createGroupRequest.GroupName,
                Users = new List<User>(),
                Events = new List<Event>()
            };
            _context.Groups.Add(group);
            _context.SaveChanges();

            return Ok(_mapper.Map<GroupDto>(group));
        }
    }
}
