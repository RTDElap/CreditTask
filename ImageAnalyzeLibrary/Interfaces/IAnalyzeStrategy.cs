
namespace ImageAnalyzeLibrary.Interfaces;

/// <summary>
/// Интерфейс, представляющий собой алгоритм определения изменения фотографии
/// </summary>
public interface IAnalyzeStrategy
{
    /// <summary>
    /// Проверяет возможность определения изменения фотографии выбранным алгоритмом
    /// </summary>
    /// <param name="image">Изображение</param>
    /// <returns>Возможность обработки</returns>
    public bool CanImageIsProcessed(Image image);

    /// <summary>
    /// Применяет алгоритм к изображению для определения изменения
    /// </summary>
    /// <param name="image"></param>
    /// <returns>Изменение изображения</returns>
    public bool ProcessImage(Image image);
}