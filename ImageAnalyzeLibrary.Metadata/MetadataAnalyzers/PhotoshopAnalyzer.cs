
using ImageAnalyzeLibrary.Metadata.Interfaces;
using MetadataExtractor.Formats.Xmp;
using XmpCore;

namespace ImageAnalyzeLibrary.Metadata.Analyzers;

public sealed class PhotoshopAnalyzer : IMetadataAnalyzer
{
    private readonly string _xmpHeader;

    private readonly string _searchValue;

    public PhotoshopAnalyzer()
    {
        _xmpHeader = "xmpMM:DocumentID";

        _searchValue = "photoshop";
    }

    public bool ContainsForgeryMetadata(IReadOnlyList<MetadataExtractor.Directory> directories)
    {
        var xmpProfiles = directories.OfType<XmpDirectory>();

        foreach ( var xmpProfile in xmpProfiles )
        {
            IXmpMeta? meta = xmpProfile.XmpMeta;

            if ( meta is null ) 
                continue;

            var propertyForCheck = meta.Properties.SingleOrDefault( p => p.Path == _xmpHeader );

            if
            (
                propertyForCheck is not null &&
                propertyForCheck.Value.Contains( _searchValue )
            )
            {
                return true;
            }
        }

        return false;
    }
}