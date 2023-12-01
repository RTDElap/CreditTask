

namespace ImageAnalyzeLibrary.Interfaces;

public interface IImageAnalyzerBuilder
{
    public IImageAnalyzerBuilder AddStrategy( IAnalyzeStrategy strategy );

    public IImageAnalyzer Build();
}