using System.Data;
using MySqlConnector;
using NoCO2;

namespace NoCO2.Controllers;
public class MySQLDatabase
{
    public static MySqlConnection connection;
    public static string server;
    public static string database;
    public static string uid;
    public static string password;

    public MySQLDatabase()
    {
        server = "databaseht.cyethqvobvkg.us-west-2.rds.amazonaws.com";
        database = "Hackathon";
        uid = "masterUsername";
        password = "masterUsername";
        string connectionString = "server=" + server + ";uid=" + uid +";pwd=" + password + ";database=" + database;

        connection = new MySqlConnection(connectionString);
    }
    
    public void CustomerIDandTotalsInEachSection(string key)
    {
            MySqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "INSERT INTO CustomerIDandTotalCo2Emmisions (CustomerID) Values (@CustomerID)";
            command.Parameters.AddWithValue("@CustomerID", key);
            command.ExecuteNonQuery();
            connection.Close();
    }

    public string GetCustomerID(string key)
    {
        string query = "SELECT CUSTOMERID FROM CustomerIDandTotalCo2Emmisions WHERE CustomerID = " + key;
        connection.Open();

        using MySqlCommand command = new MySqlCommand(query, connection);
        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            return reader.GetString("CustomerID");
        }
        return "0";
    }
}