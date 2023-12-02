
using ImageAnalyzeLibrary.Types;

namespace ImageAnalyzeLibrary.Interfaces;

/// <summary>
/// Интерфейс определения фальсификацию изображения,
/// используя цепочку алгоритмов
/// </summary>
public interface IImageAnalyzer
{
    /// <summary>
    /// Проверяет фальсификацию изображения.
    /// После первого положительного результата на фальсификацию возвращает ответ
    /// </summary>
    /// <param name="image">Изображение</param>
    /// <returns>Результат проверки</returns>
    public Result CheckImageForgery( Stream image );

    /// <summary>
    /// Проверяет фальсификацию изображения.
    /// Применяет к изображению все алгоритмы, которые находятся в цепочке и возвращает их ответы
    /// </summary>
    /// <param name="image">Изображения</param>
    /// <returns>Результаты проверки алгоритмов</returns>
    public IEnumerable<Result> CheckImageForgeryAllStrategies( Stream image );
}