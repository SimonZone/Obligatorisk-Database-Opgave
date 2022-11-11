
using System.Data.SqlClient;

internal class DBClient
{
    public void Start(string queryString)
    {
        // The connectionString is connected to my azure database with the same data as what would be in the txt files
        string connectionString = "Server=tcp:simon-sql-server-1.database.windows.net,1433;Initial Catalog=Simon_SQL_Database_1;Persist Security Info=False;User ID=SimonSAdmin;Password=SimonAzurePW1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        using SqlConnection connection = new(connectionString);
        SqlCommand command = new(queryString, connection);
        connection.Open();
        if (queryString.Contains("SELECT"))
        {
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"" + reader[i] + ", ");
                }
                Console.WriteLine();
            }
            reader.Close();
        }
        else
        {
            command.ExecuteNonQuery();
        }
        connection.Close();
    }
}

