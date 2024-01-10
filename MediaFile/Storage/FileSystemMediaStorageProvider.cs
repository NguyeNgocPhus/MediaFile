using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PNN.File.Abstraction;

namespace PNN.File.Storage;
public class FileSystemMediaStorageProvider : IMediaStorageProvider
{
    //const string MediaRootPath = "Storage";
    public bool IsCloudStorage { get; }


    public string GetPath(Domain.MediaFile mediaFile)
    {
        var ext = mediaFile.Extension;
        var fileName = mediaFile.Id.ToString();
        return $"D:\\leader\\LearnToLeader\\MediaFile\\App_data\\{mediaFile.Name}";
    }
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

    public async Task SaveAsync(Domain.MediaFile mediaFile, IImage item)
    {
        var filePath = GetPath(mediaFile);
        if (item != null)
        {
            var outStream = new FileStream(
                     filePath, FileMode.OpenOrCreate,
                      FileAccess.ReadWrite, FileShare.None);
            await item.SaveAsync(outStream);
        }
    }
}
