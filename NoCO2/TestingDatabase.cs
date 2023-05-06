
using NoCO2.Controllers;
using Xunit;

namespace NoCO2;
public class TestingDatabase
{
    [Fact]
    public void DatabaseConnectionTest()
    {
        const string num = "789";
        MySQLDatabase data = new MySQLDatabase();
        data.CustomerIDandTotalsInEachSection(num);
        Assert.Equal(num, data.GetCustomerID(num));
    }
}