
using CommandLine;
using ImageAnalyzeLibrary.Builders;
using ImageAnalyzeLibrary.Interfaces;
using ImageAnalyzeLibrary.Metadata;
using ImageAnalyzeLibrary.Types;

public static class Program
{
    internal class Options
    {
        [Option('i', "image", HelpText = "Path to image", Required = true)]
        public string? PathToImage { get; set; }
    }

    static void Main(string[] args)
    {
        if ( ! TryParseCommandLineArgs(args, out Options options) )
        {
            return;
        }

        if ( ! File.Exists( options.PathToImage ) )
        {
            Console.WriteLine("Файл не найден.");

            return;
        }

        var imageAnalyzer = BuildImageAnalyzer();

        var result = GetResultForFile( options.PathToImage, imageAnalyzer );

        if ( result.IsForgeryImage )
        {
            PrintPositiveResult(result);
        }
        else
        {
            PrintNegativeResult();
        }
    }

#region Парсинг аргументов
    static bool TryParseCommandLineArgs(string[] args, out Options options)
    {
#region 
#nullable disable
        options = default;
#endregion

        var parsedResult = Parser.Default.ParseArguments<Options>( args );

        if ( parsedResult.Value is null ) return false;

        options = parsedResult.Value;

        return true;
    }
#endregion

#region Создание imageAnalyzer и обработка изображения

    static IImageAnalyzer BuildImageAnalyzer()
    {
        return ImageAnalyzerBuilder.Create()
            .AddMetadataStrategy
            (
                cfg => cfg
                    .AnalyzePhotoshop()
            )
            .Build();
    }

    static Result GetResultForFile(string path, IImageAnalyzer analyzer)
    {
        using ( var fs = File.OpenRead( path ) )
        {
            return analyzer.CheckImageForgery(fs);
        }
    }

#endregion

#region Вывод результата
    static void PrintNegativeResult()
    {
        Console.WriteLine("Изображение прошло проверку.");
    }

    static void PrintPositiveResult(Result result)
    {
        Console.WriteLine( $"Изображение не прошло проверку." );

        Console.WriteLine( $"{result.From}: {result.Description}" );
    }
#endregion

}