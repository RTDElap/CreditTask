
using ImageAnalyzeLibrary.Interfaces;
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

    public static IImageAnalyzerBuilder AddMetadataStrategy(this IImageAnalyzerBuilder imageAnalyzer, Action<MetadataAnalyzeStrategy> configure )
    {
        MetadataAnalyzeStrategy strategy = new MetadataAnalyzeStrategy();

        configure( strategy );

        imageAnalyzer.AddStrategy( strategy );

        return imageAnalyzer;
    }
}