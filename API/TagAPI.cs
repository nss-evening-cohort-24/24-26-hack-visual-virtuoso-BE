using HackVisualVirtuosoBE.Models;
using Microsoft.EntityFrameworkCore;

namespace HackVisualVirtuosoBE.API
{
    public static class TagsAPI
    {
        public static void Map(WebApplication app)
        {

            app.MapGet("/api/tags", (HackVisualVirtuosoBEDbContext db) =>
            {
                return db.Tags.ToList();
            });

            app.MapDelete("/api/tags", (HackVisualVirtuosoBEDbContext db, int id) =>
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

            app.MapPost("/api/createTag", (HackVisualVirtuosoBEDbContext db, Tag createTag) =>
            {
                db.Tags.Add(createTag);
                db.SaveChanges();
                return Results.Created($"/api/addTag/{createTag.Id}", createTag);
            });
        }
    }
}