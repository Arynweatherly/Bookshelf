﻿using System;
using System.Collections.Generic;
using System.Text;
using Bookshelf35.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf35.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Comment> Comment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Create a new user for Identity Framework
            ApplicationUser user = new ApplicationUser
            {
                FirstName = "admin",
                LastName = "admin",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            // create some authors 

            Author author1 = new Author
            {
                Id = 1,
                Name = "Stephen King",
                ApplicationUserId = user.Id

        };

            modelBuilder.Entity<Author>().HasData(author1);

            Author author2 = new Author
            {
                Id = 2,
                Name = "Jersey Mike",
                ApplicationUserId = user.Id

            };
            modelBuilder.Entity<Author>().HasData(author2);


            Author author3 = new Author
            {
                Id = 3,
                Name = "Jared FFFFFogel",
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Author>().HasData(author3);



            //Create some Book
            Book johnBook = new Book
            {
                Id = 1,
                Title = "Free Smells",
                Genre = "Sandwiches",
                YearPublished = 1998,
                AuthorId = author1.Id,
                ApplicationUserId = user.Id,
                Rating = 4
            };
            modelBuilder.Entity<Book>().HasData(johnBook);

            Book jerseyBook = new Book
            {
                Id = 2,
                Title = "Jersey Subs",
                Genre = "Sandwiches",
                YearPublished = 2020,
                AuthorId = author2.Id,
                ApplicationUserId = user.Id,
                Rating = 5
            };
            modelBuilder.Entity<Book>().HasData(jerseyBook);

            Book fogelBook = new Book
            {
                Id = 3,
                Title = "How to make a prison sandwhich",
                Genre = "Instructional",
                YearPublished = 2015,
                ApplicationUserId = user.Id,
                AuthorId = author3.Id,
                Rating = 0
            };
            modelBuilder.Entity<Book>().HasData(fogelBook);

            //create some comments 
            Comment jerseyComment = new Comment
            {
                Id = 1,
                Text = "It smells like jersey",
                BookId = jerseyBook.Id,
                ApplicationUserId = user.Id
            };

            modelBuilder.Entity<Comment>().HasData(jerseyComment);

            Comment jimmyComment = new Comment
            {
                Id = 2,
                Text = "the fastest delivery guys and their book",
                BookId = johnBook.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Comment>().HasData(jimmyComment);

            Comment jaredComment = new Comment
            {
                Id = 3,
                Text = "the worst book ever",
                BookId = fogelBook.Id,
                ApplicationUserId = user.Id
            };
            modelBuilder.Entity<Comment>().HasData(jaredComment);

        }
    }

}