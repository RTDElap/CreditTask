
using ImageAnalyzeLibrary.Types;

namespace ImageAnalyzeLibrary.Interfaces;

/// <summary>
/// Интерфейс алгоритма определения фальсификации изображения
/// </summary>
public interface IAnalyzeStrategy
{
    /// <summary>
    /// Применяет алгоритм к изображению для определения фальсификации
    /// </summary>
    /// <param name="image"></param>
    /// <returns>Результат работы</returns>
    public Result ProcessImage( Stream image );
}