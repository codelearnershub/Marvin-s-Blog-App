using MarvinBlogv._2._0.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvinBlogv._2._0.Context
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany(c => c.AssociatedPosts)
                .WithOne(cr => cr.Category)
                .HasForeignKey(c => c.CategoryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Post>().HasMany(p => p.PostCategories)
                .WithOne(p => p.Post)
                .HasForeignKey(c => c.PostId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FullName = "Marvellous Adeoye",
                    Email = "adeoyemarvellous7@gmail.com",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "adeoyemarvellous7@gmail.com",
                    PasswordHash = "jeYMxCrAXGBEfEJB7j3IuPv4LhgThc7OIsAovL/J13Q=",
                    HashSalt = "GHAku+jJgJVENsz/Y7le9w==",
                }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "SuperAdmin",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "adeoyemarvellous7@gmail.com",
                }
            );

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    Id = 1,
                    UserId = 1,
                    RoleId = 1,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "adeoyemarvellous@gmail.com",
                }
            );
        }
    }
}
