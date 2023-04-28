using Shared.Dto.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto.Models
{
    public class PaymentDto
    {
        public Guid Id { get; set; }

        public double Balance { get; set; }

        public bool PaidStatus { get; set; }

        // relationships, this is a join-table between the User and Event tables
        public EventDto Event { get; set; } = new EventDto();

        public Guid OweingUserId { get; set; }
        public AuthModel OwingUser { get; set; } = new AuthModel();

        public Guid RecievingUserId { get; set; }
        public AuthModel RecievingUser { get; set; } = new AuthModel();
    }
}
