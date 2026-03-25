using BaltaDataAccess.Models;
using Dapper;
using Microsoft.Data.SqlClient;

public class Program
{
    public static void Main(string[] args)
    {
        const string connectionString = "Server=localhost,1433;Database=balta;User Id=sa;Password=1q2w3e4r@#$; trustServerCertificate=true;";



        using (var connection = new SqlConnection(connectionString))
        {
            UpdateCategory(connection);
            ListCategories(connection);
            // CreateCategory(connection);
        }
    }

    static void ListCategories(SqlConnection connection)
    {
        var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");

        foreach (var item in categories)
        {
            Console.WriteLine($"Id: {item.Id}, Title: {item.Title}");
        }
    }

    static void CreateCategory(SqlConnection connection)
    {
        var category = new Category();
        category.Id = Guid.NewGuid();
        category.Title = "Amazon AWS";
        category.Url = "amazon";
        category.Description = "Categoria destinada para os cursos relacionados a Amazon AWS";
        category.Order = 8;
        category.Summary = "AWS Cloud";
        category.Featured = false;

        var insertSql = @"INSERT INTO [Category]
            ([Id], [Title], [Url], [Summary], [Order], [Description], [Featured])
        VALUES
            (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

        var rows = connection.Execute(insertSql, new
        {
            category.Id,
            category.Title,
            category.Url,
            category.Summary,
            category.Order,
            category.Description,
            category.Featured,
        });
        Console.WriteLine($"Rows: {rows}");
    }

    static void UpdateCategory(SqlConnection connection)
    {
        var updateQuery = @"UPDATE [Category]
        SET
            [Title] = @Title
        WHERE
            [Id] = @Id";

        var rows = connection.Execute(updateQuery, new
        {
            Id = new Guid("daa9b6db-45bd-4ef2-9da0-c2545be469bf"),
            Title = "Amazon AWS - Updated",
        });

        Console.WriteLine($"Rows: {rows}");
    }
}