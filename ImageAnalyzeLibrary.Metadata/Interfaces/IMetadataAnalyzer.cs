
using MetadataExtractor;

namespace ImageAnalyzeLibrary.Metadata.Interfaces;

/// <summary>
/// Интерфейс, представляющий алгоритм анализа метаданных.
/// Необходим, поскольку редакторы могут использовать разные форматы для записи метаданных (например XMP и EXIF)
/// </summary>
public interface IMetadataAnalyzer
{
    /// <summary>
    /// Определяет вхождения метаданных, свидетельствующих о возможной подделке
    /// </summary>
    /// <param name="directories">Метаданные изображения</param>
    /// <returns>Флаг, указывающий на наличие метаданных</returns>
    public bool ContainsForgeryMetadata( IReadOnlyList<MetadataExtractor.Directory> directories );
}