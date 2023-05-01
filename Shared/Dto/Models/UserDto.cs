using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto.Models
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public bool WantNotification { get; set; }

        public bool DinnerTeam { get; set; }

        public string Phone { get; set; } = string.Empty;

        public bool HasMobilePay { get; set; }

        // relationships
        public IList<PaymentDto> OwedPayments { get; set; } = new List<PaymentDto>();

        public IList<PaymentDto> ReceivingPayments { get; set; } = new List<PaymentDto>();

        public IList<EventDto> Events { get; set; } = new List<EventDto>();

        public IList<GroupDto> Groups { get; set; } = new List<GroupDto>();
    }
}
