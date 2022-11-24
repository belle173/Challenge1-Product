using Xunit;

namespace Tests;

public class UnitTest1
{
    [Theory]
    [InlineData(1,0)]
    [InlineData(5,1)]
    [InlineData(1,5)]
    public void Test1(int qty, int cost)
    {
        var order = new Order().total(qty,cost);
        var result = qty * cost;

        Assert.Equal(order,result);
    }

     [Theory]
    [InlineData(1,0)]
    [InlineData(5,1)]
    [InlineData(1,5)]
    public void Test2(int qty, float cost)
    {
        var order = new Order().GST(qty,cost);
        var result = (qty * cost)/10;

        Assert.Equal(order,result);
    }
}