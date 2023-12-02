
using ImageAnalyzeLibrary.Interfaces;

namespace ImageAnalyzeLibrary.Builders;

public class ImageAnalyzerBuilder : IImageAnalyzerBuilder
{
    private readonly Queue<IAnalyzeStrategy> _strategies;

    private ImageAnalyzerBuilder()
    {
        _strategies = new();
    }

    /// <summary>
    /// Создает новый экземпляр билдера
    /// </summary>
    /// <returns></returns>
    public static ImageAnalyzerBuilder Create() =>
        new ImageAnalyzerBuilder();

    public IImageAnalyzerBuilder AddStrategy( IAnalyzeStrategy strategy )
    {
        _strategies.Enqueue( strategy );

        return this;
    }

    public IImageAnalyzer Build()
    {
        return new ImageAnalyzer( _strategies );
    }
}