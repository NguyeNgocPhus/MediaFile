using System.Drawing;

namespace PNN.File.Abstraction;
public interface IImage : IDisposable
{
    public int Width { get; set; }
    public int Height { get; set; }
    public Size SourceSize { get; }
    public Stream InStream { get; }
    public IImage Save(Stream stream);
    public Task<IImage> SaveAsync(Stream stream);
}
