

using ImageAnalyzeLibrary.Types;

namespace ImageAnalyzeLibrary.Interfaces;

public interface IImageAnalyzer
{
    public Result CheckImageForgery( Stream image );

    public IEnumerable<Result> CheckImageForgeryAllStrategies( Stream image );
}