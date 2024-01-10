using PNN.File.Abstraction;

namespace PNN.File.Storage;
public class DatabaseMediaStorageProvider : IMediaStorageProvider
{
    public bool IsCloudStorage { get; }

    public Task ChangeExtensionAsync(Domain.MediaFile mediaFile, string extension)
    {
        throw new NotImplementedException();
    }

    public Task<long> GetLengthAsync(Domain.MediaFile mediaFile)
    {
        throw new NotImplementedException();
    }

    public Task<byte[]?> LoadAsync(Domain.MediaFile mediaFile)
    {
        throw new NotImplementedException();
    }

    public Stream? OpenRead(Domain.MediaFile mediaFile)
    {
        throw new NotImplementedException();
    }

    public Task<Stream?> OpenReadAsync(Domain.MediaFile mediaFile)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(params Domain.MediaFile[] mediaFiles)
    {
        throw new NotImplementedException();
    }

    public Task SaveAsync(Domain.MediaFile mediaFile, IImage item)
    {
        throw new NotImplementedException();
    }
}
