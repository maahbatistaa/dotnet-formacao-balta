using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new BlogDataContext();

            var user = new User
            {
                Name = "Mariana Batista",
                Slug = "marianabatista",
                Email = "mariana@batista.com",
                Bio = "Dev .NET",
                Image = "https://balta.io",
                PasswordHash = "123098457"
            };

            var category = new Category
            {
                Name = "Backend",
                Slug = "backend"
            };

            var post = new Post
            {
                Author = user,
                Category = category,
                Body = "<p>Hello world</p>",
                Slug = "comecando-com-ef-core",
                Summary = "Nesse artigo vamos aprender EF core",
                Title = "Começando com EF Core",
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };

            context.Posts.Add(post);
            context.SaveChanges();
        }
    }
}