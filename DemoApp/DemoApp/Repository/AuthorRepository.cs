﻿using DemoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        public AuthorRepository()
        {
            using (var context = new ApiContext())
            {
                var authors = new List<Author>
                {
                new Author
                {
                    FirstName ="Joydip",
                    LastName ="Kanjilal",
                       Books = new List<Book>()
                    {
                        new Book { Title = "Mastering C# 8.0"},
                        new Book { Title = "Entity Framework Tutorial"},
                        new Book { Title = "ASP.NET 4.0 Programming"}
                    }
                },
                new Author
                {
                    FirstName ="Yashavanth",
                    LastName ="Kanetkar",
                    Books = new List<Book>()
                    {
                        new Book { Title = "Let us C"},
                        new Book { Title = "Let us C++"},
                        new Book { Title = "Let us C#"}
                    }
                }
                };
                context.Authors.AddRange(authors);
                context.SaveChanges();
            }
        }
        public List<Author> GetAuthors()
        {
            using (var context = new ApiContext())
            {
                var list = context.Authors
                    .Include(a => a.Books)
                    .ToList();
                return list;
            }
        }
    }
}
