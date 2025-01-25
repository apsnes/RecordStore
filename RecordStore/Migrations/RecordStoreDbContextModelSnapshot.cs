﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecordStore;

#nullable disable

namespace RecordStore.Migrations
{
    [DbContext(typeof(RecordStoreDbContext))]
    partial class RecordStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RecordStore.Entities.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("RecordStore.Entities.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Artist")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("SpotifyEmbed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Records");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Artist = "Pink Floyd",
                            ArtistId = 0,
                            Genre = "Progressive Rock",
                            ReleaseYear = 1973,
                            SpotifyEmbed = "https://open.spotify.com/embed/album/4LH4d3cOWNNsVw41Gqt2kv?utm_source=generator",
                            Title = "The Dark Side of the Moon"
                        },
                        new
                        {
                            Id = 2,
                            Artist = "The Beatles",
                            ArtistId = 0,
                            Genre = "Rock",
                            ReleaseYear = 1969,
                            SpotifyEmbed = "https://open.spotify.com/embed/album/0ETFjACtuP2ADo6LFhL6HN?utm_source=generator",
                            Title = "Abbey Road"
                        },
                        new
                        {
                            Id = 3,
                            Artist = "Michael Jackson",
                            ArtistId = 0,
                            Genre = "Pop",
                            ReleaseYear = 1982,
                            SpotifyEmbed = "https://open.spotify.com/embed/track/3S2R0EVwBSAVMd5UMgKTL0?utm_source=generator",
                            Title = "Thriller"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
