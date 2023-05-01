using Microsoft.AspNetCore.Identity;

namespace Utensils_Api.Database.Models
{
    public class User : IdentityUser<Guid>
    {
        [PersonalData]
        public bool WantNotification { get; set; }

        [PersonalData]
        public bool DinnerTeam { get; set; }

        [PersonalData]
        public string Phone { get; set; }

        [PersonalData]
        public bool HasMobilePay { get; set; }

        // relationships
        public IList<Payment> OwedPayments { get; set; } = new List<Payment>();

        public IList<Payment> ReceivingPayments { get; set; } = new List<Payment>();

        public IList<Event> Events { get; set; } = new List<Event>();

        public IList<Group> Groups { get; set; } = new List<Group>();
    }
}
