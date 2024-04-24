using HackVisualVirtuosoBE.Models;
using HackVisualVirtuosoBE.Dtos;
using Microsoft.EntityFrameworkCore;

namespace HackVisualVirtuosoBE.API
{
    public class ArtworkTagAPI
    {
        public static async void Map(WebApplication app)
        {
            app.MapPost("artwork/addTag", async (HackVisualVirtuosoBEDbContext _context, AddTagToArtworkDto addTagToArtworkDto) =>
            {
                Artwork artwork = await _context.Artwork.FirstOrDefaultAsync(t => t.Id == addTagToArtworkDto.ArtworkId);

                Tag tag = await _context.Tags.FirstOrDefaultAsync(t => t.Id == addTagToArtworkDto.TagId);
                ArtworkTag artworkTag = new()
                {
                    Tag = tag,
                    Artwork = artwork,
                };

                artwork.Tags.Add(artworkTag);

                await _context.SaveChangesAsync();

                return Results.Ok();
            });

            app.MapPost("/artwork/removetag", async (HackVisualVirtuosoBEDbContext _context, AddTagToArtworkDto addTagToArtworkDto) =>
            {
                Artwork artwork = await _context.Artwork.FirstOrDefaultAsync(t => t.Id == addTagToArtworkDto.ArtworkId);
                Tag tag = await _context.Tags.FirstOrDefaultAsync(t => t.Id == addTagToArtworkDto.TagId);
                ArtworkTag artworkTag = await _context.ArtworkTags.FirstOrDefaultAsync(t = t.tag.Id == tag.Id && t.Artwork.Id == artwork.Id);

                artwork.Tags.Remove(artworkTag);

                await _context.SaveChangesAsync();

                return Results.Ok();
            });
        }
    }
}