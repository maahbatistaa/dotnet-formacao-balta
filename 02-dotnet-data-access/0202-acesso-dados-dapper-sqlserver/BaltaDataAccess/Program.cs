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
            // CreateCategory(connection);
            // UpdateCategory(connection);
            // DeleteCategory(connection);
            // GetCategory(connection);
            // CreateManyCategory(connection);
            // ListCategories(connection);
            // ExecuteProcedure(connection);
            // ExecuteReadProcedure(connection);
            // ExecuteScalar(connection);
            // ReadView(connection);
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

    static void GetCategory(SqlConnection connection)
    {
        var category = connection
            .QueryFirstOrDefault<Category>(
                "SELECT TOP 1 [Id], [Title] FROM [Category] WHERE [Id]=@id",
                new
                {
                    id = "af3407aa-11ae-4621-a2ef-2028b85507c4"
                });
        Console.WriteLine($"{category.Id} - {category.Title}");

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

    static void DeleteCategory(SqlConnection connection)
    {
        var deleteQuery = "DELETE [Category] WHERE [Id]=@id";
        var rows = connection.Execute(deleteQuery, new
        {
            id = new Guid("ea8059a2-e679-4e74-99b5-e4f0b310fe6f"),
        });

        Console.WriteLine($"{rows} registros excluídos");
    }

    static void CreateManyCategory(SqlConnection connection)
    {
        var category = new Category();
        category.Id = Guid.NewGuid();
        category.Title = "Amazon AWS";
        category.Url = "amazon";
        category.Description = "Categoria destinada para os cursos relacionados a Amazon AWS";
        category.Order = 8;
        category.Summary = "AWS Cloud";
        category.Featured = false;

        var category2 = new Category();
        category2.Id = Guid.NewGuid();
        category2.Title = "Categoria nova";
        category2.Url = "categoria-nova";
        category2.Description = "Categoria destinada para os cursos relacionados a Categoria nova";
        category2.Order = 9;
        category2.Summary = "Categoria nova";
        category2.Featured = true;

        var insertSql = @"INSERT INTO [Category]
            ([Id], [Title], [Url], [Summary], [Order], [Description], [Featured])
        VALUES
            (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

        var rows = connection.Execute(insertSql, new[]
        {
            new
        {
            category.Id,
            category.Title,
            category.Url,
            category.Summary,
            category.Order,
            category.Description,
            category.Featured,
        },
            new
        {
            category2.Id,
            category2.Title,
            category2.Url,
            category2.Summary,
            category2.Order,
            category2.Description,
            category2.Featured,
        }});
        Console.WriteLine($"Rows: {rows}");
    }

    static void ExecuteProcedure(SqlConnection connection)
    {
        var sql = "[spDeleteStudent]";
        var pars = new { StudentId = "1b806fd0-3ce5-445f-82f0-aec2c792f1c3" };

        var affectedRows = connection.Execute(sql, pars, commandType: System.Data.CommandType.StoredProcedure);
        Console.WriteLine($"Affected rows: {affectedRows}");
    }

    static void ExecuteReadProcedure(SqlConnection connection)
    {
        var sql = "[spGetCoursesByCategory]";
        var pars = new { CategoryId = "09ce0b7b-cfca-497b-92c0-3290ad9d5142" };

        var courses = connection.Query(sql, pars, commandType: System.Data.CommandType.StoredProcedure);
        foreach (var item in courses)
        {
            Console.WriteLine($"{item.Id} - {item.Title}");
        }
    }

    static void ExecuteScalar(SqlConnection connection)
    {
        var category = new Category();
        category.Title = "Amazon AWS";
        category.Url = "amazon";
        category.Description = "Categoria destinada para os cursos relacionados a Amazon AWS";
        category.Order = 8;
        category.Summary = "AWS Cloud";
        category.Featured = false;

        var insertSql = @"INSERT INTO [Category] output inserted.Id
        VALUES
            (NEWID(), @Title, @Url, @Summary, @Order, @Description, @Featured) 
        SELECT SCOPE_IDENTITY()";

        var id = connection.ExecuteScalar<Guid>(insertSql, new
        {
            category.Title,
            category.Url,
            category.Summary,
            category.Order,
            category.Description,
            category.Featured,
        });
        Console.WriteLine($"A category ID: {id}");
    }

    static void ReadView(SqlConnection connection)
    {
        var sql = "SELECT * FROM [vwCourses]";

        var courses = connection.Query(sql);
        foreach (var item in courses)
        {
            Console.WriteLine($"{item.Id} - {item.Title} - {item.Category}");
        }
    }
}