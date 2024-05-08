using HackVisualVirtuosoBE.Dtos;
using HackVisualVirtuosoBE.Models;
using Microsoft.EntityFrameworkCore;

namespace HackVisualVirtuosoBE.API
{
    public class ArtworkAPI
    {
        public static void Map(WebApplication app)
        {
            // Get All Artwork + tags
            app.MapGet("/artwork", (HackVisualVirtuosoBEDbContext db) =>
            { 
                return db.Artwork.Include(a => a.Tags).ThenInclude(t => t.Tag).ToList();
            });

            // Get Single Artwork
            app.MapGet("/artwork/{id}", (HackVisualVirtuosoBEDbContext db, int id) =>
            {
                var artworkId = db.Artwork
                .Include(a => a.Tags)
                .ThenInclude(t => t.Tag)
                .FirstOrDefault(a => a.Id == id);
               

                if (artworkId == null)
                {
                    return Results.NotFound("No Artwork Found.");
                }

                return Results.Ok(artworkId);
            });

            // Create an Artwork
            app.MapPost("/artwork", (HackVisualVirtuosoBEDbContext db, CreateArtworkDTO artworkDTO) => //createNewArtwork
            {
                var newArtwork = new Artwork
                {
                    Title = artworkDTO.Title,
                    ImageUrl = artworkDTO.ImageUrl,
                    Description = artworkDTO.Description,
                    Tags = new List<ArtworkTag>(),
                };

                foreach (var tagId in artworkDTO.TagIds)
                {
                    var tag = db.Tags.Find(tagId);
                    if (tag != null)
                    {
                        newArtwork.Tags.Add(new ArtworkTag { Tag = tag, Artwork = newArtwork });
                    }
                }
                db.Artwork.Add(newArtwork);
                db.SaveChanges();

                var artworkId = newArtwork.Id;

                return Results.Created($"/artwork/{newArtwork.Id}", newArtwork);
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
                artworkToUpdate.Tags = new List<ArtworkTag>();

                foreach (var tagId in updateArtworkDTO.TagIds)
                {
                    var tag = db.Tags.Find(tagId);
                    if (tag != null)
                    {
                        artworkToUpdate.Tags.Add(new ArtworkTag {Tag = tag});
                    }
                }
            

                db.SaveChanges();
                return Results.Ok("The Artwork was updated!");

            });

            // search for products or sellers (case sensitive)
            app.MapGet("/api/search", (HackVisualVirtuosoBEDbContext db, string query) =>
            {
                if (string.IsNullOrWhiteSpace(query))
                {
                    return Results.BadRequest("Search query cannot be empty.");
                }
                string lowercaseQuery = query.ToLower();
                var artworks = db.Artwork.Where(p => p.Title.ToLower().Contains(lowercaseQuery))
                                          .Include(a => a.Tags)
                                          .ThenInclude(t => t.Tag)
                                          .ToList();
                var responseData = new
                {
                    artworks,
                };
                if (artworks.Count == 0)
                {
                    return Results.NotFound("No results found.");
                }
                else
                {
                    return Results.Ok(responseData);
                }
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


