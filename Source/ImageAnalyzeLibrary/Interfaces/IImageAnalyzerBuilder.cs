
namespace ImageAnalyzeLibrary.Interfaces;

/// <summary>
/// Билдер для создания цепочки алгоритмов
/// </summary>
public interface IImageAnalyzerBuilder
{
    /// <summary>
    /// Добавляет алгоритм определения фальсификации изображения в цепочку,
    /// соблюдая порядок добавления
    /// </summary>
    /// <param name="strategy">Алгоритм обработки</param>
    /// <returns></returns>
    public IImageAnalyzerBuilder AddStrategy( IAnalyzeStrategy strategy );

    /// <summary>
    /// Строит ImageAnalyzer с цепочкой алгоритмов
    /// </summary>
    /// <returns></returns>
    public IImageAnalyzer Build();
}