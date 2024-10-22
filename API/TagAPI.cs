using HackVisualVirtuosoBE.Models;
using Microsoft.EntityFrameworkCore;

namespace HackVisualVirtuosoBE.API
{
    public static class TagsAPI
    {
        public static void Map(WebApplication app)
        {

            app.MapGet("/tags", (HackVisualVirtuosoBEDbContext db) =>
            {
                return db.Tags.ToList();
            });

            app.MapGet("/tags/{id}", (HackVisualVirtuosoBEDbContext db, int id) =>
            {
                var itemId = db.Tags.FirstOrDefault(c => c.Id == id);

                if (itemId == null)
                {
                    return Results.NotFound("No Tags Found.");
                }

                return Results.Ok(itemId);
            });

            app.MapDelete("/tags", (HackVisualVirtuosoBEDbContext db, int id) =>
            {
                var tagToDelete = db.Tags.FirstOrDefault(i => i.Id == id);
                if (tagToDelete == null)
                {
                    return Results.NotFound("There was an issue with deleting the item.");
                }
                else
                {
                    db.Tags.Remove(tagToDelete);

                    db.SaveChanges();
                }
                return Results.Ok();
            });

            app.MapPost("/tags", (HackVisualVirtuosoBEDbContext db, Tag createTag) =>
            {
                db.Tags.Add(createTag);
                db.SaveChanges();
                return Results.Created($"/api/addTag/{createTag.Id}", createTag);
            });
        }
    }
}