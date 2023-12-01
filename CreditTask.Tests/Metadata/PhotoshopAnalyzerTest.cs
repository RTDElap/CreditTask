
using ImageAnalyzeLibrary.Metadata.Analyzers;
using MetadataExtractor;

namespace CreditTask.Tests;

public class PhotoshopAnalyzerTests
{
    public const string PATH_VARIABLE = "ASSETS_PATH";

    public static string PathToAssetsFolder;
    
    public static List<object[]> PathsToImages;

    static PhotoshopAnalyzerTests()
    {
        PathsToImages = new List<object[]>();

        PathToAssetsFolder = Environment.GetEnvironmentVariable( PATH_VARIABLE );

        if ( PathToAssetsFolder is null )
        {
            throw new ArgumentNullException($"Не указана переменная окружения {PATH_VARIABLE}");
        }

        foreach ( var path in System.IO.Directory.GetFiles( Path.Combine( PathToAssetsFolder, "Photoshop" ) ) )
        {
            PathsToImages.Add( [ path ] );
        }
    }

    [Fact]
    public void ContainsForgeryMetadata_False()
    {
        var photoshopAnalyzer = new PhotoshopAnalyzer();

        using ( var fs = File.OpenRead( Path.Combine( PathToAssetsFolder, "source.jpeg" ) ) )
        {
            var directories = ImageMetadataReader.ReadMetadata( fs );

            Assert.False( photoshopAnalyzer.ContainsForgeryMetadata( directories ) );
        }
    }

    [Theory]
    [MemberData( nameof(PathsToImages) )]
    public void ContainsForgeryMetadata_True(string imagePath)
    {
        var photoshopAnalyzer = new PhotoshopAnalyzer();

        using ( var fs = File.OpenRead( Path.Combine( imagePath ) ) )
        {
            var directories = ImageMetadataReader.ReadMetadata( fs );

            Assert.True( photoshopAnalyzer.ContainsForgeryMetadata( directories ) );
        }
    }
}