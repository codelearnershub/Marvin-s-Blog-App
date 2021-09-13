﻿// <auto-generated />
using System;
using MarvinBlogv._2._0.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MarvinBlogv._2._0.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20210910130523_initt")]
    partial class initt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MarvinBlogv._2._0.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ImageURL")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MarvinBlogv._2._0.Models.Follower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FollowingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartedFollowing")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Followers");
                });

            modelBuilder.Entity("MarvinBlogv._2._0.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Message")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("MarvinBlogv._2._0.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasMaxLength(100000000);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("FeaturedImageURL")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ImageURL")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PostURL")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Content")
                        .IsUnique();

                    b.HasIndex("Description")
                        .IsUnique();

                    b.HasIndex("PostURL")
                        .IsUnique();

                    b.HasIndex("Title")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("MarvinBlogv._2._0.Models.PostCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PostId");

                    b.ToTable("PostCategories");
                });

            modelBuilder.Entity("MarvinBlogv._2._0.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<bool>("Reaction")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("MarvinBlogv._2._0.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 9, 10, 14, 5, 22, 103, DateTimeKind.Local).AddTicks(2894),
                            CreatedBy = "adeoyemarvellous7@gmail.com",
                            Name = "SuperAdmin"
                        });
                });

            modelBuilder.Entity("MarvinBlogv._2._0.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("varchar(150) CHARACTER SET utf8mb4")
                        .HasMaxLength(150);

                    b.Property<string>("HashSalt")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("Email", "FullName")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 9, 10, 14, 5, 22, 97, DateTimeKind.Local).AddTicks(8240),
                            CreatedBy = "adeoyemarvellous7@gmail.com",
                            Email = "adeoyemarvellous7@gmail.com",
                            FullName = "Marvellous Adeoye",
                            HashSalt = "GHAku+jJgJVENsz/Y7le9w==",
                            PasswordHash = "jeYMxCrAXGBEfEJB7j3IuPv4LhgThc7OIsAovL/J13Q="
                        });
                });

            modelBuilder.Entity("MarvinBlogv._2._0.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 9, 10, 14, 5, 22, 103, DateTimeKind.Local).AddTicks(6452),
                            CreatedBy = "adeoyemarvellous@gmail.com",
                            RoleId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("MarvinBlogv._2._0.Models.Follower", b =>
                {
                    b.HasOne("MarvinBlogv._2._0.Models.User", "User")
                        .WithMany("Followers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MarvinBlogv._2._0.Models.Notification", b =>
                {
                    b.HasOne("MarvinBlogv._2._0.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarvinBlogv._2._0.Models.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MarvinBlogv._2._0.Models.Post", b =>
                {
                    b.HasOne("MarvinBlogv._2._0.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MarvinBlogv._2._0.Models.PostCategory", b =>
                {
                    b.HasOne("MarvinBlogv._2._0.Models.Category", "Category")
                        .WithMany("AssociatedPosts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MarvinBlogv._2._0.Models.Post", "Post")
                        .WithMany("PostCategories")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("MarvinBlogv._2._0.Models.Review", b =>
                {
                    b.HasOne("MarvinBlogv._2._0.Models.Post", "Post")
                        .WithMany("Reviews")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarvinBlogv._2._0.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MarvinBlogv._2._0.Models.UserRole", b =>
                {
                    b.HasOne("MarvinBlogv._2._0.Models.Role", "Role")
                        .WithMany("userRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MarvinBlogv._2._0.Models.User", "User")
                        .WithMany("userRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
