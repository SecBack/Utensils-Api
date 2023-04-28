using Shared.Dto.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto.Models
{
    public class GroupDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        // relationships
        public IList<EventDto> Events { get; set; } = new List<EventDto>();

        public IList<AuthModel> Users { get; set; } = new List<AuthModel>();
    }
}
