using Shared.Dto.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Shared.Dto.Models
{
    public class EventDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public EventType EventType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        // relationships
        public IList<UserDto> Users { get; set; } = new List<UserDto>();

        public IList<PaymentDto> Payment { get; set; } = new List<PaymentDto>();

        public GroupDto Group { get; set; } = new GroupDto();
    }
}
