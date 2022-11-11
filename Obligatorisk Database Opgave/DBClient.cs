
using System.Data.SqlClient;

internal class DBClient
{
    public void Start(string queryString)
    {
        // The connectionString is connected to my azure database with the same data as what would be in the txt files
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HotelDBRE;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


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

