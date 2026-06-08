using Xunit;
using LabLogic; 

namespace LabTests;

public class SampleTests
{
    [Theory]
    [InlineData("Urgent", 40, "Delayed: Urgent")]
    [InlineData("Urgent", 20, "On Time")]
    [InlineData("Normal", 150, "Delayed: Normal")]
    [InlineData("Normal", 100, "On Time")]
    [InlineData("Other", 0, "Unknown Type")]
    public void TestCheckDelay(string type, int time, string expected)
    {
        var manager = new SampleManager();
        Assert.Equal(expected, manager.CheckDelay(type, time));
    }

    [Theory]
    [InlineData("Urgent", 40, "Delayed: Urgent")]
    [InlineData("Urgent", 20, "On Time")]
    [InlineData("Normal", 150, "Delayed: Normal")]
    [InlineData("Normal", 100, "On Time")]
    [InlineData("Other", 0, "Unknown Type")]
    public void TestCheckDelayRefactored(string type, int time, string expected)
    {
        var manager = new SampleManager();
        Assert.Equal(expected, manager.CheckDelayRefactored(type, time));
    }

    [Theory]
    [InlineData("Urgent", 40, "Delayed: Urgent")]
    [InlineData("Urgent", 20, "On Time")]
    [InlineData("Normal", 150, "Delayed: Normal")]
    [InlineData("Normal", 100, "On Time")]
    [InlineData("Other", 0, "Unknown Type")]
    public void TestCheckDelayAdvanced(string type, int time, string expected)
    {
        var manager = new SampleManager();
        Assert.Equal(expected, manager.CheckDelayAdvanced(type, time));
    }
}