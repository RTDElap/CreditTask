
using ImageAnalyzeLibrary.Interfaces;
using ImageAnalyzeLibrary.Metadata.Interfaces;
using ImageAnalyzeLibrary.Types;
using MetadataExtractor;

namespace ImageAnalyzeLibrary.Metadata;

public class MetadataAnalyzeStrategy : IAnalyzeStrategy
{    
    private readonly IList<IMetadataAnalyzer> _metadataAnalyzers;

    public MetadataAnalyzeStrategy()
    {
        _metadataAnalyzers = new List<IMetadataAnalyzer>();
    }

    public MetadataAnalyzeStrategy AddAnalyzer( IMetadataAnalyzer analyzer )
    {
        _metadataAnalyzers.Add( analyzer );

        return this;
    }

    private IReadOnlyList<MetadataExtractor.Directory> GetMetadataFromImage( Stream image )
    {
        return ImageMetadataReader.ReadMetadata( image );
    }

    private bool TryGetMetadataFromImage ( Stream image, out IReadOnlyList<MetadataExtractor.Directory> metadata )
    {
        metadata = default;

        try
        {
            metadata = GetMetadataFromImage( image );

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
}