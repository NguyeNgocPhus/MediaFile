using System.Drawing;

namespace PNN.File.Abstraction;
internal class ImageWrapper : IDisposable, IImage
{
    public int Width { get; set; }
    public int Height { get; set; }
    public Size SourceSize { get; }
    public Stream InStream { get; }
    public ImageWrapper() { }
    public ImageWrapper(Stream stream, Size size)
    {
        InStream = stream;
        Width = size.Width;
        Height = size.Height;
        SourceSize = size;
    }
    public IImage Save(Stream stream)
    {

        if (stream.CanSeek)
        {
            stream.SetLength(0);
        }

        InStream.CopyTo(stream);

        if (stream.CanSeek)
        {
            stream.Position = 0;
        }

        if (InStream.CanSeek)
        {
            InStream.Position = 0;
        }

        return this;
    }

    public async Task<IImage> SaveAsync(Stream stream)
    {

        if (stream.CanSeek)
        {
            stream.SetLength(0);
        }

        await InStream.CopyToAsync(stream);

        if (stream.CanSeek)
        {
            stream.Position = 0;
        }

        if (InStream.CanSeek)
        {
            InStream.Position = 0;
        }

        return this;
    }

    public void Dispose()
    {
        InStream.Dispose();
    }
}
