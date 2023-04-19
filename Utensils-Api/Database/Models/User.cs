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
        public int Phone { get; set; }

        [PersonalData]
        public bool HasMobilePay { get; set; }

        // relationships
        public IList<Event> Events { get; set; } = new List<Event>();
    }
}
