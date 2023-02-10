﻿// <auto-generated />
using System;
using Blog_Page.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlogPage.Migrations
{
    [DbContext(typeof(BlogPageContext))]
    [Migration("20230210004738_mssql.local_migration_844")]
    partial class mssqllocalmigration844
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Blog_Page.Models.BlogPost", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BlogUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LikeCount")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlogUserId");

                    b.ToTable("BlogPosts");
                });

            modelBuilder.Entity("Blog_Page.Models.BlogUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BlogUsers");
                });

            modelBuilder.Entity("Blog_Page.Models.Comment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BlogPostId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("PostId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlogPostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Blog_Page.Models.FavoritePost", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BlogPostId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlogPostId");

                    b.ToTable("FavoritePosts");
                });

            modelBuilder.Entity("Blog_Page.Models.BlogPost", b =>
                {
                    b.HasOne("Blog_Page.Models.BlogUser", null)
                        .WithMany("FavoritePosts")
                        .HasForeignKey("BlogUserId");
                });

            modelBuilder.Entity("Blog_Page.Models.Comment", b =>
                {
                    b.HasOne("Blog_Page.Models.BlogPost", null)
                        .WithMany("Comments")
                        .HasForeignKey("BlogPostId");
                });

            modelBuilder.Entity("Blog_Page.Models.FavoritePost", b =>
                {
                    b.HasOne("Blog_Page.Models.BlogPost", "BlogPost")
                        .WithMany()
                        .HasForeignKey("BlogPostId");

                    b.Navigation("BlogPost");
                });

            modelBuilder.Entity("Blog_Page.Models.BlogPost", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Blog_Page.Models.BlogUser", b =>
                {
                    b.Navigation("FavoritePosts");
                });
#pragma warning restore 612, 618
        }
    }
}
