﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace _24_26_hack_visual_virtuoso_BE.Migrations
{
    [DbContext(typeof(HackVisualVirtuosoBEDbContext))]
    partial class HackVisualVirtuosoBEDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HackVisualVirtuosoBE.Models.Artwork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Artwork");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c5/Edvard_Munch%2C_1893%2C_The_Scream%2C_oil%2C_tempera_and_pastel_on_cardboard%2C_91_x_73_cm%2C_National_Gallery_of_Norway.jpg/800px-Edvard_Munch%2C_1893%2C_The_Scream%2C_oil%2C_tempera_and_pastel_on_cardboard%2C_91_x_73_cm%2C_National_Gallery_of_Norway.jpg",
                            Title = "The Scream",
                            UserId = "1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "",
                            ImageUrl = "https://t1.gstatic.com/licensed-image?q=tbn:ANd9GcQsu7yYuRPXNK9eHHSFD2tUYO4stQDb1Ez8vjqGERfs9xqYLLnY_y6lQkPFZa-44cqn",
                            Title = "Mona Lisa",
                            UserId = "2"
                        },
                        new
                        {
                            Id = 3,
                            Description = "",
                            ImageUrl = "https://lh3.googleusercontent.com/Pd2nCUHUz4Ruc76LRh1-H0Dldl04hWSXw8P9uCYZ4TIWP7yNPArIgWlHZrf1qT9T=s1200",
                            Title = "The Starry Night",
                            UserId = "3"
                        });
                });

            modelBuilder.Entity("HackVisualVirtuosoBE.Models.ArtworkTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtworkId")
                        .HasColumnType("integer");

                    b.Property<int>("TagId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ArtworkId");

                    b.HasIndex("TagId");

                    b.ToTable("ArtworkTags");
                });

            modelBuilder.Entity("HackVisualVirtuosoBE.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("HackVisualVirtuosoBE.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Uid")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HackVisualVirtuosoBE.Models.ArtworkTag", b =>
                {
                    b.HasOne("HackVisualVirtuosoBE.Models.Artwork", "Artwork")
                        .WithMany("Tags")
                        .HasForeignKey("ArtworkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HackVisualVirtuosoBE.Models.Tag", "Tag")
                        .WithMany("Artwork")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artwork");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("HackVisualVirtuosoBE.Models.Artwork", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("HackVisualVirtuosoBE.Models.Tag", b =>
                {
                    b.Navigation("Artwork");
                });
#pragma warning restore 612, 618
        }
    }
}
