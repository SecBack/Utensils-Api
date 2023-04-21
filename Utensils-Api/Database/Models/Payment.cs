using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utensils_Api.Database.Models
{
    public class Payment
    {
        [Key]
        public Guid Id { get; set; }

        public double Balance { get; set; }

        public bool PaidStatus { get; set; }

        // relationships, this is a join-table between the User and Event tables
        public Event Event { get; set; } = new Event();

        public Guid OweingUserId { get; set; }
        public User OwingUser { get; set; } = new User();

        public Guid RecievingUserId { get; set; }
        public User RecievingUser { get; set; } = new User();
    }
}
