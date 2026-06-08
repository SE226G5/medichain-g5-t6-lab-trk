namespace SampleTrackingModule;

public class SampleManager
{
    // الدالة الرئيسية
    public string MoveToNextStage(bool isDoc, bool isStored, bool isDamaged, string currentStage)
    {
        string error = GetValidationError(isDoc, isStored, isDamaged);
        if (error != null) return error;

        if (currentStage == "Registration")
            return "Success: Stage documented. Moving to Lab Testing.";

        if (currentStage == "LabTesting")
            return "Success: Stage documented. Moving to Review.";

        if (currentStage == "Review")
            return "Success: Stage documented. Moving to Storage.";

        return "Error: Unknown stage provided.";
    }

    // دالة منطق التحقق
    private private string GetValidationError(bool isDoc, bool isStored, bool isDamaged)
    {
        if (isDamaged) return "Error: Sample is damaged.";
        if (!isStored) return "Error: Sample not stored.";
        if (!isDoc) return "Error: Previous stage not documented.";
        return null;
    }
}
