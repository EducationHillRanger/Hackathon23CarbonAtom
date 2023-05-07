using MySqlConnector;

namespace NoCO2.Controllers;
public class MySQLDatabase
{
    // class used to create object as return statments, for total infor
    public class CustomerInfo
    {
        public string transprotTotal { get; set; }
        public string foodTotal { get; set; }
        public string clothesTotal { get; set; }
    }

    // class used to create object as return statment for all specific emissions table
    public class SpecificTableInfo
    {
        public string date { get; set; }
        public string emission { get; set; }
    }

    // private variables, information about MySQL Database on AWS RDS
    private static MySqlConnection connection;
    private static string server;
    private static string database;
    private static string uid;
    private static string password;

    // constructor sets a connection with the MySQL Database on AWS RDS 
    public MySQLDatabase()
    {
        server = "databaseht.cyethqvobvkg.us-west-2.rds.amazonaws.com";
        database = "Hackathon";
        uid = "masterUsername";
        password = "masterUsername";
        string connectionString = "server=" + server + ";uid=" + uid +";pwd=" + password + ";database=" + database;

        connection = new MySqlConnection(connectionString);
    }
    // 
    public int CustomerCreation(string key)
    {
        const int zero = 0;
        MySqlCommand command = connection.CreateCommand();
        connection.Open();
        try {
            command.CommandText = "INSERT INTO CUSTOMERIDANDTOTALS (CUSTOMERID, TRANSPORT, FOOD, CLOTHES) Values (@CUSTOMERID, @TRANSPORT, @FOOD, @CLOTHES)";
            command.Parameters.AddWithValue("@CUSTOMERID", key);
            command.Parameters.AddWithValue("@TRANSPORT", zero);
            command.Parameters.AddWithValue("@FOOD", zero);
            command.Parameters.AddWithValue("@CLOTHES", zero);
            command.ExecuteNonQuery();
            connection.Close();
            return 0;
        }
        catch (Exception)
        {
            connection.Close();
            return -1;
        }
    }

    // this retrieves all total emission records for a customer of unique "key" and returns object CustomerInfo
    // doesnt return user key for security
    public CustomerInfo GetCustomerTotalEmissions(string key)
    {
        string query = "SELECT * FROM CUSTOMERIDANDTOTALS WHERE CUSTOMERID = " + key;

        CustomerInfo customerInfo = new CustomerInfo();
        connection.Open();

        using MySqlCommand command = new MySqlCommand(query, connection);
        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            customerInfo.transprotTotal = reader.GetDecimal("TRANSPORT").ToString();
            customerInfo.clothesTotal = reader.GetDecimal("CLOTHES").ToString();
            customerInfo.foodTotal = reader.GetDecimal("FOOD").ToString();
        }
        connection.Close();
        return customerInfo;
    }

    // called when setting info to clothes daily, calls SetOrAdd method and specifies to what table this information should be added
    public int SetOrAddCustomerClothesDaily(string key, string emissions)
    {
        const string tableName = "CLOTHESDAILY";
        SetOrAddCustomerInputDaily(key, emissions, tableName);
        return 0;
    }
    // called when setting info to food daily, calls SetOrAdd method and specifies to what table this information should be added
    public int SetOrAddCustomerFoodDaily(string key, string emissions)
    {
        const string tableName = "FOODDAILY";
        SetOrAddCustomerInputDaily(key, emissions, tableName);
        return 0;
    }
    // called when setting info to transport daily, calls SetOrAdd method and specifies to what table this information should be added
    public int SetOrAddCustomerTransportDaily(string key, string emissions)
    {
        const string tableName = "TRANSPORTDAILY";
        SetOrAddCustomerInputDaily(key, emissions, tableName);
        return 0;
    }

    // this method will insert into the "input" table in the database and will either add or set the data to the table depending on return from IsInputFailyAlreadySet method
    // private, only methods within this class can call, for security
    private static void SetOrAddCustomerInputDaily(string key, string emissions, string tableName)
    {
        string date = (DateTime.UtcNow).ToString("MM/dd/yyyy");
        if (!TryToUpdateInputDaily(key, emissions, date, tableName)) {
            string query = "INSERT INTO " + tableName + " (CUSTOMERID, DATE, EMISSION) Values (@CUSTOMERID, @DATE, @EMISSION)";
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            command.Parameters.AddWithValue("@CUSTOMERID", key);
            command.Parameters.AddWithValue("@DATE", date);
            command.Parameters.AddWithValue("@EMISSION", emissions);
            command.ExecuteNonQuery();
            SetOrADDDailyTotals(key, emissions, date);
        }
        connection.Close();
    }

    // this will check if the table of name "input" has data entered already, if so it will add the new emission entry to the table in the database
    // if not it will return false making the if statment in Set0rAdd method run to set the information
    // private, only methods within this class can call, for security
    private static bool TryToUpdateInputDaily(string key, string emissions, string date, string tableName)
    {
        string query = "SELECT * FROM " + tableName + " WHERE CUSTOMERID = " + key + " AND DATE = '" + date + "'";

        connection.Open();
        using MySqlCommand command = new MySqlCommand(query, connection);
        using MySqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows) {
            double oldEmission = 0;
            while(reader.Read()) {
                oldEmission = (double)reader.GetDecimal("EMISSION");
            }
            reader.Close();
            MySqlCommand updateCommand = new MySqlCommand("UPDATE " + tableName + " SET emission = @EMISSION WHERE CUSTOMERID = @CUSTOMERID AND DATE = @DATE", connection);
            double newEmissions = oldEmission + double.Parse(emissions);
            string updatedEmission = newEmissions.ToString();
            updateCommand.Parameters.AddWithValue("@CUSTOMERID", key);
            updateCommand.Parameters.AddWithValue("@DATE", date);
            updateCommand.Parameters.AddWithValue("@EMISSION", updatedEmission);
            updateCommand.ExecuteNonQuery();
            TryToUpdateDailyTotals(key, emissions, date);
            return true;
        }
        reader.Close();
        return false;
    }
    // called when setting info to transport daily, calls Get method and specifies to what table this information should be retrieved from
    public SpecificTableInfo GetCustomerTransportDaily(string key)
    {
        const string tableName = "TRANSPORTDAILY";
        return GetCustomerInputDaily(key, tableName);
    }
    // called when setting info to clothes daily, calls Get method and specifies to what table this information should be retrieved from
    public SpecificTableInfo GetCustomerClothesDaily(string key)
    {
        const string tableName = "CLOTHESDAILY";
        return GetCustomerInputDaily(key, tableName);
    }
    // called when setting info to food daily, calls Get method and specifies to what table this information should be retrieved from
    public SpecificTableInfo GetCustomerFoodDaily(string key)
    {
        const string tableName = "FOODDAILY";
        return GetCustomerInputDaily(key, tableName);
    }
    // this will retrieve information from the MySQL database within the correct request table
    // doesnt return user key for security
    public SpecificTableInfo GetCustomerInputDaily(string key, string tableName)
    {
        string date = (DateTime.UtcNow).ToString("MM/dd/yyyy");
        string query = "SELECT * FROM " + tableName + " WHERE CUSTOMERID = " + key + " AND DATE = '" + date + "'";

        SpecificTableInfo transportInfo = new SpecificTableInfo();
        connection.Open();

        using MySqlCommand command = new MySqlCommand(query, connection);
        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            transportInfo.date = reader.GetString("DATE");
            transportInfo.emission = reader.GetDecimal("EMISSION").ToString();
        }
        connection.Close();
        return transportInfo;
    }

    public static void SetOrADDDailyTotals(string key, string emissions, string date)
    {
        if (!TryToUpdateDailyTotals(key, emissions, date)) {
            string query = "INSERT INTO DAILYTOTALS (CUSTOMERID, DATE, EMISSIONS) Values (@CUSTOMERID, @DATE, @EMISSIONS)";
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            command.Parameters.AddWithValue("@CUSTOMERID", key);
            command.Parameters.AddWithValue("@DATE", date);
            command.Parameters.AddWithValue("@EMISSIONS", emissions);
            command.ExecuteNonQuery();
        }
    }

    public static bool TryToUpdateDailyTotals(string key, string emissions, string date)
    {
        string query = "SELECT * FROM DAILYTOTALS WHERE CUSTOMERID = " + key + " AND DATE = '" + date + "'";
        using MySqlCommand command = new MySqlCommand(query, connection);
        using MySqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows) {
            double oldEmission = 0;
            while(reader.Read()) {
                oldEmission = (double)reader.GetDecimal("EMISSIONS");
            }
            reader.Close();
            MySqlCommand updateCommand = new MySqlCommand("UPDATE DAILYTOTALS SET emissions = @EMISSIONS WHERE CUSTOMERID = @CUSTOMERID AND DATE = @DATE", connection);
            double newEmissions = oldEmission + double.Parse(emissions);
            string updatedEmission = newEmissions.ToString();
            updateCommand.Parameters.AddWithValue("@CUSTOMERID", key);
            updateCommand.Parameters.AddWithValue("@DATE", date);
            updateCommand.Parameters.AddWithValue("@EMISSIONS", updatedEmission);
            updateCommand.ExecuteNonQuery();
            return true;
        }
        return false;
    }
}