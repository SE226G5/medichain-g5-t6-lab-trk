using Xunit;
using SampleTrackingModule;
namespace SampleTrackingModule.Tests;
public class SampleTrackingTests
{
    [Fact]
    public void MoveToNextStage_Damaged_ReturnsError()
    {
        var module = new SampleManager();
        var result = module.MoveToNextStage(true, true, true, "Registration");
        Assert.Equal("Error: Sample is damaged.", result);
    }
    [Fact]
    public void MoveToNextStage_NotStored_ReturnsError(){
        var module = new SampleManager();
        var result = module.MoveToNextStage(true, false, false, "Registration");
        Assert.Equal("Error: Sample not stored.", result);
    }

    [Fact]
    public void MoveToNextStage_NotDocumented_ReturnsError()
    {
        var module = new SampleManager();
        var result = module.MoveToNextStage(false, true, false, "Registration");
        Assert.Equal("Error: Previous stage not documented.", result);
    }

    [Fact]
    public void MoveToNextStage_UnknownStage_ReturnsError()
    {
        var module = new SampleManager();
        var result = module.MoveToNextStage(true, true, false, "UnknownStage");
        Assert.Equal("Error: Unknown stage provided.", result);
    }
    // حالات النجاح 

    [Fact]
    public void MoveToNextStage_FromRegistration_ReturnsSuccess()
    {
        var module = new SampleManager();
        var result = module.MoveToNextStage(true, true, false, "Registration");
        Assert.Equal("Success: Stage documented. Moving to Lab Testing.", result);
    }

    [Fact]
    public void MoveToNextStage_FromLabTesting_ReturnsSuccess()
    {
        var module = new SampleManager();
        var result = module.MoveToNextStage(true, true, false, "LabTesting");
        Assert.Equal("Success: Stage documented. Moving to Review.", result);
    }

    [Fact]
    public void MoveToNextStage_FromReview_ReturnsSuccess()
    {
        var module = new SampleManager();
        var result = module.MoveToNextStage(true, true, false, "Review");
        Assert.Equal("Success: Stage documented. Moving to Storage.", result);
    }
}

