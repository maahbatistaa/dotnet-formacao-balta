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

            //var user = new User
            //{
            //    Name = "Mariana Batista",
            //    Slug = "marianabatista",
            //    Email = "mariana@batista.com",
            //    Bio = "Dev .NET",
            //    Image = "https://balta.io",
            //    PasswordHash = "123098457"
            //};

            //var category = new Category
            //{
            //    Name = "Backend",
            //    Slug = "backend"
            //};

            //var post = new Post
            //{
            //    Author = user,
            //    Category = category,
            //    Body = "<p>Hello world</p>",
            //    Slug = "comecando-com-ef-core",
            //    Summary = "Nesse artigo vamos aprender EF core",
            //    Title = "Começando com EF Core",
            //    CreateDate = DateTime.Now,
            //    LastUpdateDate = DateTime.Now
            //};

            //context.Posts.Add(post);
            //context.SaveChanges();

            //var posts = context
            //    .Posts
            //    .AsNoTracking()
            //    .Include(x => x.Author)
            //    .Include(x => x.Category)
            //    .OrderBy(x => x.LastUpdateDate)
            //    .ToList();

            //foreach (var post in posts)
            //    Console.WriteLine($"{post.Title} escrito por {post.Author?.Name} em {post.Category?.Name}");

            var post = context
                .Posts
                //.AsNoTracking() Precisa do Tracking
                .Include(x => x.Author)
                .Include(x => x.Category)
                .OrderByDescending(x => x.LastUpdateDate)
                .FirstOrDefault(); //Pegando o primeiro item

            post.Author.Name = "Teste";
            context.Posts.Update(post);
            context.SaveChanges();
        }
    }
}