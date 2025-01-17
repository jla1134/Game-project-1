using System;
using System.Data;
using System.Data.SqlClient;

public class DatabaseUpdater
{
    private string connectionString;

    public DatabaseUpdater(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void PushUpdate(string query, params SqlParameter[] parameters)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddRange(parameters);
                
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Update successful. Rows affected: {rowsAffected}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occurred: {ex.Message}");
                }
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Your_Connection_String_Here";
        DatabaseUpdater updater = new DatabaseUpdater(connectionString);

        // Example update
        string updateQuery = "UPDATE Users SET Name = @Name WHERE Id = @Id";
        SqlParameter[] parameters = {
            new SqlParameter("@Name", "John Doe"),
            new SqlParameter("@Id", 1)
        };

        updater.PushUpdate(updateQuery, parameters);
    }
}

