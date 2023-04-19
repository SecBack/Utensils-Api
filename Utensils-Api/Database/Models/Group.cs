namespace Utensils_Api.Database.Models
{
    public class Group
    {
        public string Name { get; set; } = string.Empty;

        // relationships
        public IList<Event> Events { get; set; } = new List<Event>();

        public IList<User> Users { get; set; } = new List<User>();
    }
}
