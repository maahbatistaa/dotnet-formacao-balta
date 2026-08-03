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

            Console.WriteLine("Teste");
        }
    }
}