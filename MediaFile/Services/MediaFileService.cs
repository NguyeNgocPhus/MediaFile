using PNN.File.Abstraction;
using PNN.File.Enums;

namespace PNN.File.Services;
public class MediaFileService : IMediaService
{
    private readonly IFolderService _folderService;

    public MediaFileService(IFolderService folderService)
    {
        _folderService = folderService;
    }

    public string CombinePaths(params string[] paths)
    {
        return FolderService.NormalizePath(Path.Combine(paths), false);
    }

    public async Task<Domain.MediaFile> SaveFileAsync(string path, Stream stream, bool isTransient = true, DuplicateFileHandling duplicateFileHandling = DuplicateFileHandling.ThrowError)
    {

        

        return new Domain.MediaFile();
    }
}
