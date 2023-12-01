

namespace ImageAnalyzeLibrary.Types;

public struct Result
{
    public string? From;

    public string? Description;

    public Result(string from, string description)
    {
        From = from;
        Description = description;
    }

    public Result MarkAsForgeryImage()
    {
        IsForgeryImage = true;
    
        return this;
    }

    public bool IsForgeryImage { get; private set; } = false;
}