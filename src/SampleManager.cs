namespace SampleTrackingModule;
public class SampleManager
{
    public string MoveToNextStage(bool isDoc, bool isStored, bool isDamaged, string currentStage)
    {
        if (isDamaged) return "Error: Sample is damaged.";
        if (!isStored) return "Error: Sample not stored.";
        if (!isDoc) return "Error: Previous stage not documented.";

        if (currentStage == "Registration")
            return "Success: Stage documented. Moving to Lab Testing.";
        
        else if (currentStage == "LabTesting")
            return "Success: Stage documented. Moving to Review.";
        
        else if (currentStage == "Review")
            return "Success: Stage documented. Moving to Storage.";
        
        return "Error: Unknown stage provided."; 
    }
}