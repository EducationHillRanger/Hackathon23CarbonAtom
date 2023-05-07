
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
        MySQLDatabase data = new();

        MySQLDatabase.CustomerInfo customerInfo = new();

        data.CustomerCreation(num);
        Assert.Equal(numEmpty, data.GetCustomerTotalEmissions(num).ClothesTotal);
        Assert.Equal(numEmpty, data.GetCustomerTotalEmissions(num).FoodTotal);
        Assert.Equal(numEmpty, data.GetCustomerTotalEmissions(num).TransprotTotal);
    }

    [Fact]
    public void TransportTotalCreateTest()
    {
        const string num = "789";
        const string emission = "78.00000";
        string finalEmission = (78 + 78.55000).ToString();
        MySQLDatabase data = new();
        data.SetOrAddCustomerTransportDaily(num, emission);
        Assert.Equal(finalEmission, data.GetCustomerTransportDaily(num).Emission);
    }

    [Fact]
    public void ClothesTotalCreateTest()
    {
        const string num = "789";
        const string emission = "78.00000";
        string finalEmission = (156 + 78.00000).ToString();
        MySQLDatabase data = new();
        data.SetOrAddCustomerClothesDaily(num, emission);
        Assert.Equal(finalEmission, data.GetCustomerClothesDaily(num).Emission);
    }

    [Fact]
    public void FoodTotalCreateTest()
    {
        const string num = "789";
        const string emission = "22.00000";
        string finalEmission = (156 + 78.00000).ToString();
        MySQLDatabase data = new();
        data.SetOrAddCustomerFoodDaily(num, emission);
        Assert.Equal(finalEmission, data.GetCustomerFoodDaily(num).Emission);
    }

    [Fact]
    public void DuplicateCustomerID()
    {
        const string num = "345";
        MySQLDatabase data = new();
        const int faultNum = -1;
        Assert.Equal(faultNum, data.CustomerCreation(num));
    }

    [Fact]
    public void LastThreeDaysTest()
    {
        const string custID = "789";
        MySQLDatabase data = new MySQLDatabase();
        KeyValuePair<string, string> response = (data.GetLastThreeEntries(custID))[0];
        KeyValuePair<string, string> response2 = (data.GetLastThreeEntries(custID))[1];
        KeyValuePair<string, string> response3 = (data.GetLastThreeEntries(custID))[2];
        Assert.Equal("05/08/2023", response.Key);
        Assert.Equal("78.00000", response.Value);
        Assert.Equal("05/07/2023", response2.Key);
        Assert.Equal("256.00000", response2.Value);
        Assert.Equal("-1", response3.Key);
        Assert.Equal("-1", response3.Value);
    }
}