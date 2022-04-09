﻿// <auto-generated />
using ChordViewer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ChordViewer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ChordViewer.Models.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("ChordViewer.Models.CollectionTabRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CollectionId")
                        .HasColumnType("integer");

                    b.Property<int>("TabId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.HasIndex("TabId");

                    b.ToTable("CollectionTabRelations");
                });

            modelBuilder.Entity("ChordViewer.Models.CollectionUserRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CollectionId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.HasIndex("UserId");

                    b.ToTable("CollectionUserRelations");
                });

            modelBuilder.Entity("ChordViewer.Models.Tab", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<int>("StringCount")
                        .HasColumnType("integer");

                    b.Property<string>("ToneKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Tabs");
                });

            modelBuilder.Entity("ChordViewer.Models.TabBarre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Fret")
                        .HasColumnType("integer");

                    b.Property<int>("StringBegin")
                        .HasColumnType("integer");

                    b.Property<int>("StringEnd")
                        .HasColumnType("integer");

                    b.Property<int>("SuggestedFinger")
                        .HasColumnType("integer");

                    b.Property<int>("TabId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TabId");

                    b.ToTable("TabBarre");
                });

            modelBuilder.Entity("ChordViewer.Models.TabString", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Fret")
                        .HasColumnType("integer");

                    b.Property<int>("StringOrder")
                        .HasColumnType("integer");

                    b.Property<int>("SuggestedFinger")
                        .HasColumnType("integer");

                    b.Property<int>("TabId")
                        .HasColumnType("integer");

                    b.Property<string>("Tune")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TabId");

                    b.ToTable("TabStrings");
                });

            modelBuilder.Entity("ChordViewer.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ChordViewer.Models.Collection", b =>
                {
                    b.HasOne("ChordViewer.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("ChordViewer.Models.CollectionTabRelation", b =>
                {
                    b.HasOne("ChordViewer.Models.Collection", "Collection")
                        .WithMany("TabRelations")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChordViewer.Models.Tab", "Tab")
                        .WithMany()
                        .HasForeignKey("TabId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collection");

                    b.Navigation("Tab");
                });

            modelBuilder.Entity("ChordViewer.Models.CollectionUserRelation", b =>
                {
                    b.HasOne("ChordViewer.Models.Collection", "Collection")
                        .WithMany("UserRelations")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChordViewer.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collection");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ChordViewer.Models.Tab", b =>
                {
                    b.HasOne("ChordViewer.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("ChordViewer.Models.TabBarre", b =>
                {
                    b.HasOne("ChordViewer.Models.Tab", "Tab")
                        .WithMany("TabBarre")
                        .HasForeignKey("TabId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tab");
                });

            modelBuilder.Entity("ChordViewer.Models.TabString", b =>
                {
                    b.HasOne("ChordViewer.Models.Tab", "Tab")
                        .WithMany("TabStrings")
                        .HasForeignKey("TabId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tab");
                });

            modelBuilder.Entity("ChordViewer.Models.Collection", b =>
                {
                    b.Navigation("TabRelations");

                    b.Navigation("UserRelations");
                });

            modelBuilder.Entity("ChordViewer.Models.Tab", b =>
                {
                    b.Navigation("TabBarre");

                    b.Navigation("TabStrings");
                });
#pragma warning restore 612, 618
        }
    }
}
