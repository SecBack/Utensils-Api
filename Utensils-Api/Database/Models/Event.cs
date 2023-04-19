using Shared;
using System.ComponentModel.DataAnnotations;

namespace Utensils_Api.Database.Models
{
    public class Event
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public EventType EventType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        // relationships
        public IList<User> Users { get; set; } = new List<User>();

        public Group Group { get; set; } = new Group();

        public Payment Payment { get; set; } = new Payment();
    }
}
