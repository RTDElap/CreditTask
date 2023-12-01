
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

    public MetadataAnalyzeStrategy Add( IMetadataAnalyzer analyzer )
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
            return new Result();
        }

        foreach ( var analyzer in _metadataAnalyzers )
        {
            if ( analyzer.ContainsForgeryMetadata( metadata ) )
            {
                return new Result( nameof(MetadataAnalyzeStrategy), "имееются метаданные редакторов" )
                    .MarkAsForgeryImage();
            }
        }

        return new Result();
    }
}