
using ImageAnalyzeLibrary.Interfaces;
using ImageAnalyzeLibrary.Metadata.Analyzers;
using ImageAnalyzeLibrary.Metadata.Interfaces;

namespace ImageAnalyzeLibrary.Metadata;

/// <summary>
/// Статические методы расширения для MetadataAnalyzeStrategy и билдера ImageAnalyzer
/// </summary>
public static class MetadataAnalyzeExtensions
{
    /// <summary>
    /// Добавляет проверку метаданных Photoshop
    /// </summary>
    /// <param name="strategy"></param>
    /// <returns></returns>    
    public static MetadataAnalyzeStrategy AnalyzePhotoshop(this MetadataAnalyzeStrategy strategy)
    {
        IMetadataAnalyzer analyzer = new PhotoshopAnalyzer();

        strategy.AddAnalyzer( analyzer );

        return strategy;
    }

    /// <summary>
    /// Добавляет проверку метаданных изображения
    /// </summary>
    /// <param name="imageAnalyzer"></param>
    /// <param name="configure">Метод конфигурирования алгоритма</param>
    /// <returns></returns>
    public static IImageAnalyzerBuilder AddMetadataStrategy(this IImageAnalyzerBuilder imageAnalyzer, Action<MetadataAnalyzeStrategy> configure )
    {
        MetadataAnalyzeStrategy strategy = new MetadataAnalyzeStrategy();

        configure( strategy );

        imageAnalyzer.AddStrategy( strategy );

        return imageAnalyzer;
    }
}