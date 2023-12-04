using MediaFile.Abstraction;

namespace MediaFile.Services;
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
}