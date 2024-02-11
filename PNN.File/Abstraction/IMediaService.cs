using PNN.File.Domain;
using PNN.File.Enums;

namespace PNN.File.Abstraction;
public interface IMediaService
{
    Task<Domain.MediaFile> SaveFileAsync(string path, Stream stream, bool isTransient = true, DuplicateFileHandling duplicateFileHandling = DuplicateFileHandling.ThrowError);
    string CombinePaths(params string[] paths);
    Task<bool> FolderExists(string path);
    Task<MediaFolder> CreateFolderAsync(string path);
}
