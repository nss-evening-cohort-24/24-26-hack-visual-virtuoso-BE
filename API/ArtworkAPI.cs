using HackVisualVirtuosoBE.Dtos;
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
            app.MapPost("/artwork", (HackVisualVirtuosoBEDbContext db, CreateArtworkDTO artworkDTO) => //createNewArtwork
            {
                var createArtwork = new Artwork
                {
                    Title = artworkDTO.Title,
                    ImageUrl = artworkDTO.ImageUrl,
                    Description = artworkDTO.Description,
                    Tags = new List<ArtworkTag>(),
                };

                foreach (var tagId in artworkDTO.TagIds)
                {
                    var tag = db.Tags.Find(tagId);
                    if (tag == null)
                    {
                        createArtwork.Tags.Add(new ArtworkTag { Tag = tag, Artwork = createArtwork });
                    }
                }

                db.Artwork.Add(createArtwork);
                db.SaveChanges();

                var artworkId = createArtwork.Id;

                return Results.Created($"/artwork/{createArtwork.Id}", createArtwork);
            });

            // Update an Artwork
            app.MapPut("/artwork/{id}", (HackVisualVirtuosoBEDbContext db, int id, UpdateArtworkDTO updateArtworkDTO) => //updateArtwork
            {
                var artworkToUpdate = db.Artwork.SingleOrDefault(a => a.Id == id);

                if (artworkToUpdate == null)
                {
                    return Results.NotFound("Artwork not found");
                }

                artworkToUpdate.Title = updateArtworkDTO.Title;
                artworkToUpdate.ImageUrl = updateArtworkDTO.ImageUrl;
                artworkToUpdate.Description = updateArtworkDTO.Description;
                db.SaveChanges();
                return Results.Ok("The Artwork was updated!");

            });



            // Delete an Artwork
            app.MapDelete("/artwork/{id}", (HackVisualVirtuosoBEDbContext db, int id) =>
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
                return Results.Ok($"The Artwork {id} has been deleted.");
            });

        }
    }

}


