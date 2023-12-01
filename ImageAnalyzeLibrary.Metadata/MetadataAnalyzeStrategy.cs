
using ImageAnalyzeLibrary.Interfaces;
using ImageAnalyzeLibrary.Metadata.Interfaces;
using MetadataExtractor;

namespace ImageAnalyzeLibrary.Metadata;

public class MetadataAnalyzeStrategy : IAnalyzeStrategy
{    
    private readonly IList<IMetadataAnalyzer> _metadataAnalyzers;

    private MetadataAnalyzeStrategy()
    {
        _metadataAnalyzers = new List<IMetadataAnalyzer>();
    }

    public static MetadataAnalyzeStrategy Create() =>
        new MetadataAnalyzeStrategy();

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

    public bool ProcessImage(Stream image)
    {
        if ( ! TryGetMetadataFromImage( image, out var metadata ) )
        {
            return false;
        }

        foreach ( var analyzer in _metadataAnalyzers )
        {
            if ( analyzer.ContainsForgeryMetadata( metadata ) )
            {
                return true;
            }
        }

        return false;
    }
}