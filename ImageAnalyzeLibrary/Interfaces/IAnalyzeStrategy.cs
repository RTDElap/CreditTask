
namespace ImageAnalyzeLibrary.Interfaces;

/// <summary>
/// Интерфейс, представляющий собой алгоритм определения изменения фотографии
/// </summary>
public interface IAnalyzeStrategy
{
    /// <summary>
    /// Применяет алгоритм к изображению для определения изменения
    /// </summary>
    /// <param name="image"></param>
    /// <returns>Изменение изображения</returns>
    public bool ProcessImage(Stream image);
}