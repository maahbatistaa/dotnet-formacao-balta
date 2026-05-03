using Microsoft.Data.SqlClient;
using Dapper.Contrib.Extensions;
using Blog.Models;

namespace Blog
{
	class Program
	{
		private const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User Id=sa;Password=1q2w3e4r@#$; trustServerCertificate=true;";
		static void Main(string[] args)
		{
			ReadUsers();
			//ReadUser();
			//CreateUser();
			//UpdateUser();
			//DeleteUser();
		}

		public static void ReadUsers()
		{
			using (var connection = new SqlConnection(CONNECTION_STRING))
			{
				var users = connection.GetAll<User>();
				foreach (var user in users)
				{
					Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Email: {user.Email}");
				}
			}
		}

		private static void ReadUser()
		{
			using (var connection = new SqlConnection(CONNECTION_STRING))
			{
				var user = connection.Get<User>(1);
				Console.WriteLine(user.Name);
			}
		}

		public static void CreateUser()
		{
			var user = new User
			{
				Name = "John Doe",
				Email = "john.doe@example.com",
				PasswordHash = "hashed_password",
				Bio = "Software developer and blogger.",
				Image = "https://example.com/images/john_doe.jpg",
				Slug = "john-doe"
			};

			using (var connection = new SqlConnection(CONNECTION_STRING))
			{
				connection.Insert<User>(user);
				Console.WriteLine("Cadastro realizado com sucesso!");
			}
		}

		public static void UpdateUser()
		{
			var user = new User
			{
				Id = 2,
				Name = "John Doe 1",
				Email = "john.doe@example.com",
				PasswordHash = "hashed_password",
				Bio = "Software developer and blogger.",
				Image = "https://example.com/images/john_doe.jpg",
				Slug = "john-doe-1"
			};

			using (var connection = new SqlConnection(CONNECTION_STRING))
			{
				connection.Update<User>(user);
				Console.WriteLine("Atualização realizada com sucesso!");
			}
		}

		public static void DeleteUser()
		{


			using (var connection = new SqlConnection(CONNECTION_STRING))
			{
				var user = connection.Get<User>(2);
				connection.Delete<User>(user);
				Console.WriteLine("Exclusão realizada com sucesso!");
			}
		}
	}
}