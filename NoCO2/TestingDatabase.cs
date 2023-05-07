
using NoCO2.Controllers;
using Xunit;

namespace NoCO2;
public class TestingDatabase
{
    [Fact]
    public void DatabaseConnectionTest()
    {
        const string num = "456";
        const string numEmpty = "0.00000";
        MySQLDatabase data = new MySQLDatabase();

        MySQLDatabase.CustomerInfo customerInfo = new MySQLDatabase.CustomerInfo();

        data.CustomerCreation(num);
        Assert.Equal(numEmpty, data.GetCustomerTotalEmissions(num).clothesTotal);
        Assert.Equal(numEmpty, data.GetCustomerTotalEmissions(num).foodTotal);
        Assert.Equal(numEmpty, data.GetCustomerTotalEmissions(num).transprotTotal);
    }

    [Fact]
    public void TransportTotalCreateTest()
    {
        const string num = "789";
        const string emission = "78.00000";
        string finalEmission = (78 + 78.55000).ToString();
        MySQLDatabase data = new MySQLDatabase();
        data.SetOrAddCustomerTransportDaily(num, emission);
        Assert.Equal(finalEmission, data.GetCustomerTransportDaily(num).emission);
    }

    [Fact]
    public void ClothesTotalCreateTest()
    {
        const string num = "789";
        const string emission = "78.00000";
        string finalEmission = (156 + 78.00000).ToString();
        MySQLDatabase data = new MySQLDatabase();
        data.SetOrAddCustomerClothesDaily(num, emission);
        Assert.Equal(finalEmission, data.GetCustomerClothesDaily(num).emission);
    }

    [Fact]
    public void FoodTotalCreateTest()
    {
        const string num = "789";
        const string emission = "22.00000";
        string finalEmission = (156 + 78.00000).ToString();
        MySQLDatabase data = new MySQLDatabase();
        data.SetOrAddCustomerFoodDaily(num, emission);
        Assert.Equal(finalEmission, data.GetCustomerFoodDaily(num).emission);
    }

    [Fact]
    public void DuplicateCustomerID()
    {
        const string num = "345";
        MySQLDatabase data = new MySQLDatabase();
        const int faultNum = -1;
        Assert.Equal(faultNum, data.CustomerCreation(num));
    }
}