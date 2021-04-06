﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp.DataClassLibrary;

namespace WebApp.DataClassLibrary.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20210406140037_TestMig")]
    partial class TestMig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApp.DataClassLibrary.Models.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("CommentApprovement")
                        .HasColumnType("smallint");

                    b.Property<int?>("CommentAuthorID")
                        .HasColumnType("int");

                    b.Property<string>("CommentContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CommentEditedUTC")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CommentParentID")
                        .HasColumnType("int");

                    b.Property<int>("CommentPostID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CommentPostedUTC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int>("CommentRP")
                        .HasColumnType("int");

                    b.HasKey("CommentID");

                    b.HasIndex("CommentAuthorID");

                    b.HasIndex("CommentParentID");

                    b.HasIndex("CommentPostID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("WebApp.DataClassLibrary.Models.Hashtag", b =>
                {
                    b.Property<int>("HashtagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("HashtagID");

                    b.ToTable("Hashtags");
                });

            modelBuilder.Entity("WebApp.DataClassLibrary.Models.Post", b =>
                {
                    b.Property<int>("PostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("PostApprovement")
                        .HasColumnType("smallint");

                    b.Property<int?>("PostAuthorID")
                        .HasColumnType("int");

                    b.Property<int?>("PostCategoryID")
                        .HasColumnType("int");

                    b.Property<string>("PostContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PostDateUTC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PostEditedUTC")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostRP")
                        .HasColumnType("int");

                    b.Property<string>("PostTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("PostID");

                    b.HasIndex("PostAuthorID");

                    b.HasIndex("PostID", "PostTitle")
                        .IsUnique();

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("WebApp.DataClassLibrary.Models.PostTagPair", b =>
                {
                    b.Property<int>("PostTagPairID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HashtagID")
                        .HasColumnType("int");

                    b.Property<int>("PostID")
                        .HasColumnType("int");

                    b.HasKey("PostTagPairID");

                    b.HasIndex("HashtagID");

                    b.HasIndex("PostID");

                    b.HasIndex("PostTagPairID")
                        .IsUnique();

                    b.ToTable("PostTagPairs");
                });

            modelBuilder.Entity("WebApp.DataClassLibrary.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserEMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("UserLastLoginUTC")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserLogin")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("UserPass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UserRegisteredUTC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserWebsite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("UserEMail")
                        .IsUnique();

                    b.HasIndex("UserLogin")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApp.DataClassLibrary.Models.Comment", b =>
                {
                    b.HasOne("WebApp.DataClassLibrary.Models.User", "CommentAuthor")
                        .WithMany("Comments")
                        .HasForeignKey("CommentAuthorID");

                    b.HasOne("WebApp.DataClassLibrary.Models.Comment", "CommentParent")
                        .WithMany("ChildComments")
                        .HasForeignKey("CommentParentID");

                    b.HasOne("WebApp.DataClassLibrary.Models.Post", "CommentPost")
                        .WithMany("Comments")
                        .HasForeignKey("CommentPostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp.DataClassLibrary.Models.Post", b =>
                {
                    b.HasOne("WebApp.DataClassLibrary.Models.User", "PostAuthor")
                        .WithMany("Posts")
                        .HasForeignKey("PostAuthorID");
                });

            modelBuilder.Entity("WebApp.DataClassLibrary.Models.PostTagPair", b =>
                {
                    b.HasOne("WebApp.DataClassLibrary.Models.Hashtag", "Hashtag")
                        .WithMany("TagPostPairs")
                        .HasForeignKey("HashtagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.DataClassLibrary.Models.Post", "Post")
                        .WithMany("PostTagPairs")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}