
using ImageAnalyzeLibrary.Types;

namespace ImageAnalyzeLibrary.Interfaces;

/// <summary>
/// Представляет собой интерфейс определения подделки изображения,
/// используя цепочку алгоритмов
/// </summary>
public interface IImageAnalyzer
{
    /// <summary>
    /// Проверяет подделку изображения.
    /// После первого положительного результата возвращает ответ,
    /// если нет - возвращает default структуру
    /// </summary>
    /// <param name="image">Изображение</param>
    /// <returns>Позитивный или негативный результат</returns>
    public Result CheckImageForgery( Stream image );

    /// <summary>
    /// Проверяет подделку изображения.
    /// Применяет к изображению все алгоритмы, которые находятся в цепочке и возвращает их ответы
    /// </summary>
    /// <param name="image">Изображения</param>
    /// <returns>Позитивные/негативные результаты алгоритмов</returns>
    public IEnumerable<Result> CheckImageForgeryAllStrategies( Stream image );
}