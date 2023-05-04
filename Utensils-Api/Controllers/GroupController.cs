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
    [Route("api/groups")]
    [ApiController]
    //[Authorize]
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

        [HttpGet("{id}")]
        public ActionResult<GroupDto> GetGroupMembers(Guid id)
        {
            // get group including users and events
            Group? group = _context.Groups
                .Include(g => g.Users)
                .FirstOrDefault(g => g.Id == id);

            if (group == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GroupDto>(group));
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

        // this method updates the group. if the user is not in the group, they are added to the group
        // and if the user is in the group, they are removed from the group
        [HttpPut("/update")]
        public ActionResult<GroupDto> UpdateGroup([FromBody] UpdateGroupRequest updateGroupRequest)
        {
            Group? group = _context.Groups
                .Include(g => g.Users)
                .FirstOrDefault(g => g.Id == updateGroupRequest.GroupId);

            if (group == null)
            {
                return NotFound();
            }

            if (group.Users.Any(u => u.Id == updateGroupRequest.UserId))
            {
                // remove user from group if they are in the group
                User? user = _context.Users.FirstOrDefault(u => u.Id == updateGroupRequest.UserId);
                if (user == null)
                {
                    return NotFound();
                }
                group.Users.Remove(user);
            }
            else
            {
                // add user to group if they are not in the group
                User? user = _context.Users.FirstOrDefault(u => u.Id == updateGroupRequest.UserId);
                if (user == null)
                {
                    return NotFound();
                }
                group.Users.Add(user);
            }

            _context.SaveChanges();
            return Ok(_mapper.Map<GroupDto>(group));
        }
    }
}
