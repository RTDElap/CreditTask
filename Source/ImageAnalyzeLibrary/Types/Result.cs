

namespace ImageAnalyzeLibrary.Types;

/// <summary>
/// Представляет базовый результат алгоритма
/// </summary>
public class Result
{
    private Result(Type from, string description)
    {
        From = from;
        Description = description;
    }

    public static Result CreateFrom<TFrom>( string description )
    {
        return new Result( typeof(TFrom), description );
    }

    /// <summary>
    /// Помечает результат как имеющий подделку
    /// </summary>
    /// <returns></returns>
    public Result MarkAsForgeryImage()
    {
        IsForgeryImage = true;
    
        return this;
    }

    public bool IsForgeryImage { get; private set; } = false;

    public Type From { get; private set; }

    public string Description { get; private set; }
}