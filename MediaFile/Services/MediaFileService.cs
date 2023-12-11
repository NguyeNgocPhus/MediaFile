using Microsoft.EntityFrameworkCore;
using PNN.File.Abstraction;
using PNN.File.Databases;
using PNN.File.Domain;
using PNN.File.Enums;

namespace PNN.File.Services;
public class MediaFileService : IMediaService
{
    private readonly IFolderService _folderService;
    private readonly MediaHelper _helper;
//    private readonly MediaFileDbContext _db;

    public MediaFileService(IFolderService folderService, MediaHelper helper)
    {
        _folderService = folderService;
        _helper = helper;
       // _db = db;
    }

    public string CombinePaths(params string[] paths)
    {
        return FolderService.NormalizePath(Path.Combine(paths), false);
    }

    public async Task<Domain.MediaFile> SaveFileAsync(string path, Stream stream, bool isTransient = true, DuplicateFileHandling duplicateFileHandling = DuplicateFileHandling.ThrowError)
    {

        var pathData = CreatePath(path);
       // var file = await _db.MediaFiles.FirstOrDefaultAsync(x => x.Name == pathData.Name && x.FolderId == pathData.Id);
        //var idDupe = file != null;
        //var result = new ProcessFileAsync();

        return new Domain.MediaFile();
    }
    private MediaFolder CreatePath(string path)
    {

        if (!_helper.TokenizePath(path, true))
        {
            throw new ArgumentException("path is not valid", nameof(path));
        }

        return new MediaFolder();
    }
    private Domain.MediaFile ProcessFileAsync(
        Domain.MediaFile file, 
        MediaFolder pathData, 
        //Stream inStream, 
        //HashSet<string> destFileNames = null,
        //bool isTransient = true,
        DuplicateFileHandling dupeFileHandling = DuplicateFileHandling.ThrowError
       // MimeValidationType mediaValidationType = MimeValidationType.MimeTypeMustMatch
        )
    {

        if(file != null)
        {
            var madeUniqueFileName = dupeFileHandling == DuplicateFileHandling.Overwrite ? false : true;

            if(dupeFileHandling == DuplicateFileHandling.ThrowError)
            {
                var fullPath = pathData.IncludePath;

            }
        }
        return file;
    }
}
