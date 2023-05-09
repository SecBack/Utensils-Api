using Shared;
using System.ComponentModel.DataAnnotations;
using Utensils_Api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

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

        public IList<Payment> Payments { get; set; } = new List<Payment>();

        public Group Group { get; set; } = new Group();
    }
}
