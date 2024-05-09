using HackVisualVirtuosoBE.Models;
using HackVisualVirtuosoBE.Dtos;
using Microsoft.EntityFrameworkCore;

namespace HackVisualVirtuosoBE.API
{
    public class ArtworkTagAPI
    {
      
public static async void Map(WebApplication app)
        {
            // Get Single ArtworkTag
            app.MapGet("/artworkTag/by-artworkId/{artworkId}", (HackVisualVirtuosoBEDbContext db, int artworkId) =>
            {
                var artworkTagsFilteredByArtworkId = db.ArtworkTags.Where(p => p.ArtworkId == artworkId).ToList();

                //If a Product doesn't match
                if (!artworkTagsFilteredByArtworkId.Any())
                {
                    return Results.NotFound("Unfortunately there are no Products available for this ArtworkId.");
                }

                return Results.Ok(artworkTagsFilteredByArtworkId);
            });

            app.MapPost("/artwork/{artworkId}/tags/{tagsId}", async (HackVisualVirtuosoBEDbContext db, int artworkId, int tagId) =>
            {
                // Check if the Artwork is in the Database
                var artwork = db.Artwork.FirstOrDefault(a => a.Id == artworkId);
                if (artwork == null)
                {
                    return Results.NotFound("The Artwork was not found.");
                }

                // Check to see if the Tag exists
                var tag = db.Tags.FirstOrDefault(t => t.Id == tagId);
                if (tag == null)
                {
                    return Results.NotFound("The Tag was not found");
                }

                // Check if the tag is already attached
                var existingArtworkTag = db.ArtworkTags.Where(at => (at.ArtworkId == artworkId) && (at.TagId == tagId)).FirstOrDefault();
                if (existingArtworkTag == null)
                {
                    var artworkTag = new ArtworkTag
                    {
                        ArtworkId = artworkId,
                        TagId = tagId
                    };
                    db.ArtworkTags.Add(artworkTag);
                    db.SaveChanges();

                    var tagName = tag.Name;

                    return Results.Ok($"{tagName} has been added to the Artwork {artworkId}.");
                }
                else
                {
                    return Results.NotFound("The Tag was already existing");
                }

            });

            app.MapDelete("/artwork/{artworkId}/tags/{artworkTagId}", async (HackVisualVirtuosoBEDbContext db, int artworkId, int artworkTagId) =>
            {
                var artworkTag = await db.ArtworkTags
                .Include(at => at.Tag)
                .Where(at => at.ArtworkId == artworkId && at.Id == artworkTagId)
                .FirstOrDefaultAsync();

                if (artworkTag == null)
                {
                    return Results.NotFound("This Tag was not found in this Artwork");
                }

                // Now Fetch the Specific Artwork
                var artwork = await db.Artwork.FindAsync(artworkId);
                if (artwork == null)
                {
                    return Results.NotFound("Artwork not found");
                }

                // Remove the ArtworkTag from the Database
                db.ArtworkTags.Remove(artworkTag);
                await db.SaveChangesAsync();

                return Results.Ok(new { Message = $"{artworkTag.Tag.Name} has been removed from the Artwork {artworkId}." });
            });
        }
    }
}