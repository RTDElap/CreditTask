
using ImageAnalyzeLibrary.Metadata.Analyzers;
using ImageAnalyzeLibrary.Metadata.Interfaces;

namespace ImageAnalyzeLibrary.Metadata;

public static class MetadataAnalyzeExtensions
{
    public static MetadataAnalyzeStrategy AnalyzePhotoshop(this MetadataAnalyzeStrategy strategy)
    {
        IMetadataAnalyzer analyzer = new PhotoshopAnalyzer();

        strategy.Add( analyzer );

        return strategy;
    }
}