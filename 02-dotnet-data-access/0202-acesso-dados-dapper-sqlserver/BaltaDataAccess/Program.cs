using BaltaDataAccess.Models;
using Dapper;
using Microsoft.Data.SqlClient;

const string connectionString = "Server=localhost;Database=balta;User ID=sa;Password=1q2w3e4r@#$; TrustServerCertificate=True;";

using (var connection = new SqlConnection(connectionString))
{
   UpdateCategory(connection);
   ListCategories(connection);
   // CreateCategory(connection);
}

static void ListCategories(SqlConnection connection)
{
   var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");

   foreach (var item in categories)
   {
      Console.WriteLine($"Id: {item.Id} - Title: {item.Title}");
   }
}

static void CreateCategory(SqlConnection connection)
{
   var category = new Category();
   category.Id = Guid.NewGuid();
   category.Title = "Amazon AWS";
   category.Url = "amazon";
   category.Description = "Categoria destinada para artigos relacionados a Amazon AWS";
   category.Order = 8;
   category.Summary = "Categoria destinada para artigos relacionados a Amazon AWS";
   category.Featured = false;

   var insertSql = @"INSERT INTO [Category] VALUES (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";
   var rows = connection.Execute(insertSql, new
   {
      category.Id,
      category.Title,
      category.Url,
      category.Summary,
      category.Order,
      category.Description,
      category.Featured
   });

   Console.WriteLine($"Total de linhas inseridas: {rows}");
}

static void UpdateCategory(SqlConnection connection)
{
   var updateQuery = @"UPDATE [Category] SET [Title] = @Title WHERE [Id] = @Id";
   var rows = connection.Execute(updateQuery, new
   {
      Id = new Guid("3732e4d1-a4f2-4f55-8300-49c26973dcae"),
      Title = "Amazon AWS - Atualizado"
   });

   Console.WriteLine($"Total de linhas atualizadas: {rows}");
}