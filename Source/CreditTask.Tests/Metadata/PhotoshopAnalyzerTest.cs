
using ImageAnalyzeLibrary.Metadata.Analyzers;
using MetadataExtractor;

namespace CreditTask.Tests;

public class PhotoshopAnalyzerTests
{
    /// <summary>
    /// Название переменной окружения для поиска ассетов
    /// </summary>
    public const string PATH_VARIABLE = "ASSETS_PATH";

    public static string PathToAssetsFolder;

    /// <summary>
    /// Путь ко всем изображениям для проведения тестов
    /// </summary>    
    public static List<object[]> PathsToImages;

#region Настройка окружения

    static PhotoshopAnalyzerTests()
    {
        PathsToImages = new List<object[]>();

        PathToAssetsFolder = Environment.GetEnvironmentVariable( PATH_VARIABLE ) ??
            throw new ArgumentNullException($"Не указана переменная окружения {PATH_VARIABLE}");

        IEnumerable<string> imagePaths = System.IO.Directory.GetFiles
        (
            Path.Combine( PathToAssetsFolder, "Photoshop" )
        );

        foreach ( var path in imagePaths )
        {
            PathsToImages.Add( [ path ] );
        }
    }

#endregion

#region Проверка чистых файлов

    [Fact]
    public void ContainsForgeryMetadata_False()
    {
        var photoshopAnalyzer = new PhotoshopAnalyzer();

        using ( var fs = File.OpenRead( Path.Combine( PathToAssetsFolder, "source.jpeg" ) ) )
        {
            var directories = ImageMetadataReader.ReadMetadata( fs );

            Assert.False( photoshopAnalyzer.ContainsForgeryMetadata( directories ).IsForgeryImage );
        }
    }

#endregion

#region Проверка файлов с метаданными

    [Theory]
    [MemberData( nameof(PathsToImages) )]
    public void ContainsForgeryMetadata_True(string imagePath)
    {
        var photoshopAnalyzer = new PhotoshopAnalyzer();

        using ( var fs = File.OpenRead( imagePath ) )
        {
            var directories = ImageMetadataReader.ReadMetadata( fs );

            Assert.True( photoshopAnalyzer.ContainsForgeryMetadata( directories ).IsForgeryImage );
        }
    }

#endregion

}