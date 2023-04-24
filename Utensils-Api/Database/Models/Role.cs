using Microsoft.AspNetCore.Identity;

namespace Utensils_Api.Database.Models
{
    public class Role : IdentityRole<Guid>
    {
        public string Description { get; set; } = string.Empty;
    }
}
