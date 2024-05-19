using Npgsql;
using System;
using System.Threading.Tasks;

namespace LinguaVerse_App.Database // Sample file for database connection
{
    public class DatabaseConnection
    {
        public async Task ConnectAndReadAsync()
        {
            var connString = "Host=localhost;Username=postgres;Password=;Database=LinguaVerse";

            try
            {
                Console.WriteLine("Attempting to open a connection to the database...");
                using (var conn = new NpgsqlConnection(connString))
                {
                    await conn.OpenAsync();
                    Console.WriteLine("Connection opened successfully.");

                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT * FROM mytable";
                        Console.WriteLine("Executing SQL command: " + cmd.CommandText);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            Console.WriteLine("Reading data from the database...");
                            while (await reader.ReadAsync())
                            {
                                Console.WriteLine("Data retrieved: " + reader.GetString(0));
                            }
                        }
                        Console.WriteLine("Data read successfully.");
                    }
                    Console.WriteLine("Closing the connection.");
                }
                Console.WriteLine("Connection closed successfully.");
            }
            catch (Npgsql.PostgresException ex)
            {
                Console.WriteLine($"PostgresException: {ex.Message}");
                Console.WriteLine($"Detail: {ex.Detail}");
                Console.WriteLine($"Hint: {ex.Hint}");
                Console.WriteLine($"Severity: {ex.Severity}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
