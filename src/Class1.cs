namespace LabLogic;

public class SampleManager
{
    public string CheckDelay(string type, int time)
    {
        if (type == "Urgent")
        {
            if (time > 30) return "Delayed: Urgent";
            else return "On Time";
        }
        else if (type == "Normal")
        {
            if (time > 120) return "Delayed: Normal";
            else return "On Time";
        }
        return "Unknown Type";
    }

    public string CheckDelayRefactored(string type, int time) => (type, time) switch
    {
        ("Urgent", > 30) => "Delayed: Urgent",
        ("Normal", > 120) => "Delayed: Normal",
        ("Urgent", _) => "On Time",
        ("Normal", _) => "On Time",
        _ => "Unknown Type"
    };
    public string CheckDelayAdvanced(string type, int time)
{
    var rules = new Dictionary<(string, bool), string>
    {
        { ("Urgent", true), "Delayed: Urgent" },
        { ("Normal", true), "Delayed: Normal" },
        { ("Urgent", false), "On Time" },
        { ("Normal", false), "On Time" }
    };

    bool isDelayed = (type == "Urgent" && time > 30) || (type == "Normal" && time > 120);
    
    return rules.TryGetValue((type, isDelayed), out var result) ? result : "Unknown Type";
}
}