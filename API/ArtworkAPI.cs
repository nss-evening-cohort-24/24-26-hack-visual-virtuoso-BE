using HackVisualVirtuosoBE.Models;

namespace HackVisualVirtuosoBE.API
{
    public class ArtworkAPI
    {
        public static void Map(WebApplication app)
        {
            // Get All Artwork
            app.MapGet("/api/artwork", (HackVisualVirtuosoBEDbContext db) =>
            {
                return db.Artwork.ToList();
            });

            // Get Single Artwork
            app.MapGet("/api/artwork/{id}", (HackVisualVirtuosoBEDbContext db, int id) =>
            {
                var itemId = db.Artwork.FirstOrDefault(c => c.Id == id);

                if (itemId == null)
                {
                    return Results.NotFound("No Artwork Found.");
                }

                return Results.Ok(itemId);
            });

            // Delete Artwork
            app.MapDelete("/artwork", (HackVisualVirtuosoBEDbContext db, int id) =>
            {
                var artworkToDelete = db.Artwork.FirstOrDefault(artwork => artwork.Id == id);
                if (artworkToDelete == null)
                {
                    return Results.NotFound("No Artwork Found.");
                }
                else
                {
                    db.Artwork.Remove(artworkToDelete);

                    db.SaveChanges();
                }
                return Results.Ok();
            });

        }
    }

}


