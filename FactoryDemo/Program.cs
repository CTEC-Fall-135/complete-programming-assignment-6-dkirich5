using System.Data.Common;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string provider = "SqlServer";
        string connectionString = "Data Source=(localdb)\\mssqllocaldb;Integrated Security=true;Initial Catalog=AutoLot2023";

        DbProviderFactory factory = SqlClientFactory.Instance;

        using DbConnection connection = factory.CreateConnection();
        connection.ConnectionString = connectionString;
        connection.Open();

        Console.WriteLine($"provider is: {provider}");
        Console.WriteLine($"connection string: {connectionString}");
        Console.WriteLine($"Your connection object is a: {connection.GetType().Name}");

        using DbCommand command = connection.CreateCommand();
        command.CommandText = "SELECT Id, MakeId, Color, PetName FROM Inventory";

        Console.WriteLine($"Your command object is a: {command.GetType().Name}");

        using DbDataReader reader = command.ExecuteReader();
        Console.WriteLine($"Your data reader object is a: {reader.GetType().Name}");


        while (reader.Read())
        {
            int id = reader.GetInt32(reader.GetOrdinal("Id"));
            int makeId = reader.GetInt32(reader.GetOrdinal("MakeId"));
            string color = reader.GetString(reader.GetOrdinal("Color"));
            string petName = reader.GetString(reader.GetOrdinal("PetName"));

            Console.WriteLine($"-> Car #{id}: MakeId={makeId}, Color={color}, PetName={petName}");
        }
    }
}