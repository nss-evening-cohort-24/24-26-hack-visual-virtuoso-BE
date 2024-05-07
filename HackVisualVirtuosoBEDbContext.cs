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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artwork>().HasData(new Artwork[]
        {
            new Artwork { Id = 1, Title = "The Scream", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c5/Edvard_Munch%2C_1893%2C_The_Scream%2C_oil%2C_tempera_and_pastel_on_cardboard%2C_91_x_73_cm%2C_National_Gallery_of_Norway.jpg/800px-Edvard_Munch%2C_1893%2C_The_Scream%2C_oil%2C_tempera_and_pastel_on_cardboard%2C_91_x_73_cm%2C_National_Gallery_of_Norway.jpg", Description = "", UserId = "1", Tags = []},
            new Artwork { Id = 2, Title = "Mona Lisa", ImageUrl = "https://t1.gstatic.com/licensed-image?q=tbn:ANd9GcQsu7yYuRPXNK9eHHSFD2tUYO4stQDb1Ez8vjqGERfs9xqYLLnY_y6lQkPFZa-44cqn", Description = "", UserId = "2"},
            new Artwork { Id = 3, Title = "The Starry Night", ImageUrl = "https://lh3.googleusercontent.com/Pd2nCUHUz4Ruc76LRh1-H0Dldl04hWSXw8P9uCYZ4TIWP7yNPArIgWlHZrf1qT9T=s1200", Description = "", UserId = "3"}
        });

        modelBuilder.Entity<ArtworkTag>().HasData(new ArtworkTag[]
        {
            new ArtworkTag { Id = 1, ArtworkId = 1, TagId = 1 },
        });

        modelBuilder.Entity<Tag>().HasData(new Tag[]
        {
            new Tag { Id = 1, Name = "Surrealism" },
            new Tag { Id = 2, Name = "Impressionism"},
            new Tag { Id = 3, Name = "Abstract"},
            new Tag { Id = 4, Name = "Realism"},
            new Tag { Id = 5, Name = "Cubism"},
            new Tag { Id = 6, Name = "Portraiture"},
            new Tag { Id = 7, Name = "Romanticism"}
        });
    }


}
   