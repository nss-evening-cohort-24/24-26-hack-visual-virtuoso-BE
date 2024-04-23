using Microsoft.EntityFrameworkCore;
using HackVisualVirtuosoBE.Models;

public class HackVisualVirtuosoBEDbContext : DbContext
{
    public DbSet<Artwork> Artwork { get; set; }

    public DbSet<Tag> Tags { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ArtworkTag> ArtworkTags { get; set; }

    public HackVisualVirtuosoBEDbContext(DbContextOptions<HackVisualVirtuosoBEDbContext> context) : base(context)
    {

    }
}