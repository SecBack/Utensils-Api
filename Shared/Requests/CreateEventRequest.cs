using Shared.Dto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Requests
{
    public class CreateEventRequest
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public EventType EventType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        // relationships
        public GroupDto Group { get; set; } = new GroupDto();
        public Guid UserId { get; set; }
    }
}
