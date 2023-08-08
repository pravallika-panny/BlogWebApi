﻿using BlogWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogWebAPI.Context
{


    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection")
        {
           //Database.SetInitializer<DatabaseContext>(new UserSeedDataDBInitializer<DatabaseContext>());
            Database.SetInitializer<DatabaseContext>(new SeedDataDBInitializer<DatabaseContext>());

        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Comments> PostComments { get; set; }
        public DbSet<User> Users { get; set; }

        private class UserSeedDataDBInitializer<T> : DropCreateDatabaseIfModelChanges<DatabaseContext>
        {
            protected override void Seed(DatabaseContext context)
            {
                List<User> users = GetSeedDataUserDetails();
                foreach (User user in users)
                    context.Users.Add(user);
                base.Seed(context);
                context.SaveChanges();

            }
        }
        private class SeedDataDBInitializer<T> : DropCreateDatabaseAlways<DatabaseContext>
        {
            protected override void Seed(DatabaseContext context)
            {
               
                List<Author> authors = GetSeedDataAuthorDetails();
                foreach (Author author in authors)
                    context.Authors.Add(author);
                List<BlogPost> blogs = GetSeedDataBlogDetails();
                foreach (BlogPost blog in blogs)
                    context.BlogPosts.Add(blog);
                List<Comments> postcomment = GetSeedDataCommentDetails();
                foreach (Comments comment in postcomment)
                    context.PostComments.Add(comment);
                base.Seed(context);

            }
        }

        public static List<User> GetSeedDataUserDetails()
        {
            List<User> users = new List<User>();
            users.Add(new User()
            {
                Id = 1,
                Name = "pravllika",
                Email= "pravllika@gmail.com",
                Password = "password",
                RoleName = "admin"
            });
            users.Add(new User()
            {
                Id = 2,
                Name = "Author01",
                Email = "Author01@gmail.com",
                Password = "author1",
                RoleName = "User"
            });
            users.Add(new User()
            {
                Id = 3,
                Name = "Author02@gmail.com",
                Password = "author2",
                RoleName = "User"
            });

            return users;
        }

        public static List<Author> GetSeedDataAuthorDetails()
        {
            List<Author> authors = new List<Author>();
            authors.Add(new Author()
            {
                AuthorId = 1,
                UserId = 2
            });
            authors.Add(new Author()
            {
                AuthorId = 2,
                UserId = 3
            });

            return authors;
        }

        public static List<BlogPost> GetSeedDataBlogDetails()
        {
            List<BlogPost> blogs = new List<BlogPost>();
            blogs.Add(new BlogPost()
            {
                BlogPostId = 1,
                Title = "Example post",
                Summary = "This is an example post",
                Body = "This is just some post. This part should contain all the markup generated by the WYSIWIG editor.",
                AuthorId = 1,
                Tags = new string[]
            {
                "example",
                "post"
            }
            });
            blogs.Add(new BlogPost()
            {
                BlogPostId = 2,
                Title = "sample post",
                Summary = "This is an sample post",
                Body = "This is just some post. This part should contain all the markup generated by the sample Html editor.",
                AuthorId = 1,
                Tags = new string[]
             {
                "example",
                "post"
             }
            });

            return blogs;
        }

        public static List<Comments> GetSeedDataCommentDetails()
        {
            List<Comments> comment = new List<Comments>();
            comment.Add(new Comments()
            {
                CommentId = 1,
                Description = "Test Comment1 on  Post1",
                PostId = 1

            });
            comment.Add(new Comments()
            {
                CommentId = 2,
                Description = "Test Comment2 on  Post2",
                PostId = 1

            });
            comment.Add(new Comments()
            {
                CommentId = 3,
                Description = "Test Comment1 on  Post2",
                PostId = 2

            });
            comment.Add(new Comments()
            {
                CommentId = 4,
                Description = "Test Comment1 on  Post2",
                PostId = 2

            });

            return comment;
        }


    }
}