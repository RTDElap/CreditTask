
using ImageAnalyzeLibrary.Metadata.Interfaces;
using ImageAnalyzeLibrary.Types;
using MetadataExtractor.Formats.Xmp;
using XmpCore;

namespace ImageAnalyzeLibrary.Metadata.Analyzers;

/// <summary>
/// Проверяет значение DocumentId в XMP профиле на содержание строки "photoshop";
/// </summary>
public sealed class PhotoshopAnalyzer : IMetadataAnalyzer
{
    private readonly string _xmpPathOfValue;

    private readonly string _searchValue;

    public PhotoshopAnalyzer()
    {
        _xmpPathOfValue = "xmpMM:DocumentID";

        _searchValue = "photoshop";
    }

    public Result ContainsForgeryMetadata(IReadOnlyList<MetadataExtractor.Directory> directories)
    {
        var xmpProfiles = directories.OfType<XmpDirectory>();

        IXmpMeta? meta;

        foreach ( var xmpProfile in xmpProfiles )
        {
            meta = xmpProfile.XmpMeta;

            if ( meta is null ) 
                continue;

            var propertyForCheck = meta.Properties.SingleOrDefault( p => p.Path == _xmpPathOfValue );

            if
            (
                propertyForCheck is not null &&
                propertyForCheck.Value.Contains( _searchValue, StringComparison.CurrentCultureIgnoreCase )
            )
            {
                return Result.CreateFrom<PhotoshopAnalyzer>($"имеются метаданные Photoshop ({_xmpPathOfValue} = {propertyForCheck.Value})")
                    .MarkAsForgeryImage();
            }
        }

        return Result.CreateFrom<PhotoshopAnalyzer>("метаданные не обнаружены");
    }
}