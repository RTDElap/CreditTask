using ImageAnalyzeLibrary.Interfaces;
using ImageAnalyzeLibrary.Types;

namespace ImageAnalyzeLibrary;

public sealed class ImageAnalyzer : IImageAnalyzer
{
    private readonly IEnumerable<IAnalyzeStrategy> _strategies;

    public ImageAnalyzer( IEnumerable<IAnalyzeStrategy> strategies )
    {
        _strategies = strategies;
    }

    public Result CheckImageForgery(Stream image)
    {
        foreach ( var strategy in _strategies )
        {
            var result = strategy.ProcessImage( image );

            if ( result.IsForgeryImage )
            {
                return result;
            }
        }

        return Result.CreateFrom<ImageAnalyzer>("Изображение прошло проверку");
    }

    public IEnumerable<Result> CheckImageForgeryAllStrategies(Stream image)
    {
        foreach ( var strategy in _strategies )
        {
            var result = strategy.ProcessImage( image );

            yield return result;
        }
    }
}