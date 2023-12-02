
using ImageAnalyzeLibrary.Interfaces;
using ImageAnalyzeLibrary.Metadata.Interfaces;
using ImageAnalyzeLibrary.Types;
using MetadataExtractor;

namespace ImageAnalyzeLibrary.Metadata;

/// <summary>
/// Стратегия проверки фальсификации изображения на основе его метаданных
/// </summary>
public class MetadataAnalyzeStrategy : IAnalyzeStrategy
{    
    private readonly IList<IMetadataAnalyzer> _metadataAnalyzers;

    public MetadataAnalyzeStrategy()
    {
        _metadataAnalyzers = new List<IMetadataAnalyzer>();
    }

    /// <summary>
    /// Добавляет метод анализа метаданных
    /// </summary>
    /// <param name="analyzer">Метод анализа метаданных</param>
    /// <returns></returns>
    public MetadataAnalyzeStrategy AddAnalyzer( IMetadataAnalyzer analyzer )
    {
        _metadataAnalyzers.Add( analyzer );

        return this;
    }

    /// <summary>
    /// Проверяет метаданные изображения, которые свидетельствуют фальсификации
    /// </summary>
    /// <param name="image">Изображение</param>
    /// <returns></returns>
    public Result ProcessImage(Stream image)
    {
        if ( ! TryGetMetadataFromImage( image, out var metadata ) )
        {
            return Result.CreateFrom<MetadataAnalyzeStrategy>("не удалось извлечь метаданные");
        }

        Result resultOfAnalyze;

        foreach ( var analyzer in _metadataAnalyzers )
        {
            resultOfAnalyze = analyzer.ContainsForgeryMetadata( metadata );

            if ( resultOfAnalyze.IsForgeryImage )
            {
                return resultOfAnalyze;
            }
        }

        return Result.CreateFrom<MetadataAnalyzeStrategy>("изображение не содержит метаданные редакторов");
    }

    private IReadOnlyList<MetadataExtractor.Directory> GetMetadataFromImage( Stream image )
    {
        return ImageMetadataReader.ReadMetadata( image );
    }

    private bool TryGetMetadataFromImage ( Stream image, out IReadOnlyList<MetadataExtractor.Directory> metadata )
    {
#region 
#nullable disable
        metadata = default;
#endregion

        try
        {
            metadata = GetMetadataFromImage( image );

            if ( image.CanSeek )
            {
                image.Seek(0, 0);
            }

            return true;
        }
        catch ( ImageProcessingException )
        {
            return false;
        }
        catch ( IOException )
        {
            return false;
        }
    }
}