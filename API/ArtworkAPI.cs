using HackVisualVirtuosoBE.Models;

namespace HackVisualVirtuosoBE.API
{
    public class ArtworkAPI
    {
        public static void Map(WebApplication app)
        {
            // Get All Artwork
            app.MapGet("/artwork", (HackVisualVirtuosoBEDbContext db) =>
            {
                return db.Artwork.ToList();
            });

            // Get Single Artwork
            app.MapGet("/artwork/{id}", (HackVisualVirtuosoBEDbContext db, int id) =>
            {
                var itemId = db.Artwork.FirstOrDefault(c => c.Id == id);

                if (itemId == null)
                {
                    return Results.NotFound("No Artwork Found.");
                }

                return Results.Ok(itemId);
            });

            // Create an Artwork
            app.MapPost("/artwork", (HackVisualVirtuosoBEDbContext db, Artwork newArtwork) => //createNewArtwork
            {
                db.Artwork.Add(newArtwork);
                db.SaveChanges();
                return Results.Created($"/artwork/{newArtwork.Id}", newArtwork);
            });

            // Update an Artwork
            app.MapPut("/artwork/{id}", (HackVisualVirtuosoBEDbContext db, int id, Artwork updatedArtwork) => //updateArtwork
            {
                var artworkToUpdate = db.Artwork.SingleOrDefault(a => a.Id == id);

                if (artworkToUpdate == null)
                {
                    return Results.NotFound("Artwork not found");
                }

                artworkToUpdate.Title = updatedArtwork.Title;
                artworkToUpdate.ImageUrl = updatedArtwork.ImageUrl;
                db.SaveChanges();
                return Results.Ok("The Artwork was updated!");

            });



            // Delete an Artwork
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


