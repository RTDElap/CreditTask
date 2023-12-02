

namespace ImageAnalyzeLibrary.Types;

/// <summary>
/// Представляет результат работы алгоритма
/// </summary>
public class Result
{
    private Result(Type from, string description)
    {
        From = from;
        Description = description;
    }

    /// <summary>
    /// Создает новый результат
    /// </summary>
    /// <param name="description">Описание результата</param>
    /// <typeparam name="TFrom">Тип, создавший результат</typeparam>
    /// <returns></returns>
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

    /// <summary>
    /// Является ли изображение фальсификацией
    /// </summary>
    /// <value></value>
    public bool IsForgeryImage { get; private set; } = false;

    /// <summary>
    /// Тип, создавший результат
    /// </summary>
    /// <value></value>
    public Type From { get; private set; }

    /// <summary>
    /// Описание результата
    /// </summary>
    /// <value></value>
    public string Description { get; private set; }
}