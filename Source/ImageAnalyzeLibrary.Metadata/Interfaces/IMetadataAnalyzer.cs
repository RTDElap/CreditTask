
using ImageAnalyzeLibrary.Types;
using MetadataExtractor;

namespace ImageAnalyzeLibrary.Metadata.Interfaces;

/// <summary>
/// Интерфейс алгоритма проверки метаданных.
/// </summary>
public interface IMetadataAnalyzer
{
    /// <summary>
    /// Проверяет наличие метаданных, которые свидетельствуют о возможной фальсификации
    /// </summary>
    /// <param name="directories">Метаданные изображения</param>
    /// <returns>Результат алгоритма</returns>
    public Result ContainsForgeryMetadata( IReadOnlyList<MetadataExtractor.Directory> directories );
}