namespace Utensils_Api.Database.Models
{
    public class Payment
    {
        public double Balance { get; set; }

        public bool PaidStatus { get; set; }

        // relationships, this is a join-table between the User and Event tables
        public Event Event { get; set; } = new Event();

        public User OwingUser { get; set; } = new User();

        public User RecievingUser { get; set; } = new User();
    }
}
