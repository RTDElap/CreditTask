
using CommandLine;
using ImageAnalyzeLibrary.Builders;
using ImageAnalyzeLibrary.Interfaces;
using ImageAnalyzeLibrary.Metadata;

public static class Program
{
    internal class Options
    {
        [Option('i', "image", HelpText = "Path to image", Required = true)]
        public string PathToImage { get; set; }
    }

    static void Main(string[] args)
    {
        var parsedResult = Parser.Default.ParseArguments<Options>( args );

        if ( parsedResult.Value is null ) return;

        var options = parsedResult.Value;

        IImageAnalyzer imageAnalyzer = ImageAnalyzerBuilder.Create()
            .AddMetadataStrategy
            (
                cfg => cfg.AnalyzePhotoshop()
            )
            .Build();

        if ( ! File.Exists( options.PathToImage ) )
        {
            Console.WriteLine("Файл не найден.");

            return;
        }

        using ( var fs = File.OpenRead( options.PathToImage ) )
        {
            var result = imageAnalyzer.CheckImageForgery( fs );

            if ( result.IsForgeryImage )
            {
                Console.WriteLine( $"Изображение было изменено в редакторе." );

                Console.WriteLine( $"{result.From}: {result.Description}" );
            }
            else
            {
                Console.WriteLine("Изображение не имеет метаданных");
            }
        }
    }
}