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

        public IList<Payment> Payment { get; set; } = new List<Payment>();

        public Group Group { get; set; } = new Group();
    }


public static class EventEndpoints
{
	public static void MapEventEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Event").WithTags(nameof(Event));

        group.MapGet("/", async (ApplicationDbContext db) =>
        {
            return await db.Events.ToListAsync();
        })
        .WithName("GetAllEvents")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Event>, NotFound>> (Guid id, ApplicationDbContext db) =>
        {
            return await db.Events.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Event model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetEventById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (Guid id, Event @event, ApplicationDbContext db) =>
        {
            var affected = await db.Events
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, @event.Id)
                  .SetProperty(m => m.Title, @event.Title)
                  .SetProperty(m => m.Description, @event.Description)
                  .SetProperty(m => m.EventType, @event.EventType)
                  .SetProperty(m => m.StartDate, @event.StartDate)
                  .SetProperty(m => m.EndDate, @event.EndDate)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateEvent")
        .WithOpenApi();

        group.MapPost("/", async (Event @event, ApplicationDbContext db) =>
        {
            db.Events.Add(@event);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Event/{@event.Id}",@event);
        })
        .WithName("CreateEvent")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (Guid id, ApplicationDbContext db) =>
        {
            var affected = await db.Events
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteEvent")
        .WithOpenApi();
    }
}}
