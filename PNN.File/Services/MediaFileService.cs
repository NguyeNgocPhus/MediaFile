using System.Drawing;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using PNN.File.Abstraction;
using PNN.File.Databases;
using PNN.File.Enums;
using System.IO;

namespace PNN.File.Services;
public class MediaFileService : IMediaService
{
    private readonly IFolderService _folderService;
    private readonly MediaHelper _helper;
    private readonly IMediaTypeResolver _mediaTypeResolver;
    private readonly MediaFileDbContext _db;
    private readonly IMediaStorageProvider _storageProvider;
    private readonly FileExtensionContentTypeProvider _contentTypeProvider = new FileExtensionContentTypeProvider();

    public MediaFileService(IFolderService folderService, MediaHelper helper, MediaFileDbContext db, IMediaStorageProvider storageProvider, IMediaTypeResolver mediaTypeResolver)
    {
        _folderService = folderService;
        _helper = helper;
        _db = db;
        _storageProvider = storageProvider;
        _mediaTypeResolver = mediaTypeResolver;
    }

    public string CombinePaths(params string[] paths)
    {
        return FolderService.NormalizePath(Path.Combine(paths), false);
    }

    public async Task<Domain.MediaFile> SaveFileAsync(string path, Stream stream, bool isTransient = true, DuplicateFileHandling duplicateFileHandling = DuplicateFileHandling.ThrowError)
    {

        var pathData = CreatePathData(path);
        var file = await _db.MediaFiles.FirstOrDefaultAsync(x => x.Name == pathData.FileName);
        var idDupe = file != null;

        var result = await ProcessFileAsync(file, pathData, stream, dupeFileHandling: duplicateFileHandling);
        file = result.File;
        file.CreatedAt = DateTimeOffset.UtcNow;
        file.UpdatedAt = DateTimeOffset.UtcNow;
        if (file.Id == 0)
        {
            _db.MediaFiles.Add(file);
        }
        try
        {

            await _db.SaveChangesAsync();
            await _storageProvider.SaveAsync(file, result.Image);

        }
        catch (Exception ex)
        {


        }


        return new Domain.MediaFile();
    }
    private MediaPathData CreatePathData(string path)
    {

        if (!_helper.TokenizePath(path, true))
        {
            throw new ArgumentException("path is not valid", nameof(path));
        }

        _ = _contentTypeProvider.TryGetContentType(path, out var mineType);
        var pathData = new MediaPathData()
        {
            Extension = Path.GetExtension(path)[1..],
            FileName = Path.GetFileName(path),
            FileTitle = Path.GetFileNameWithoutExtension(path),
            MimeType = mineType
        };

       
        return pathData;
    }
    private async Task<(IImage Image, Domain.MediaFile File)> ProcessFileAsync(
        Domain.MediaFile file,
        MediaPathData pathData,
        Stream inStream,
        DuplicateFileHandling dupeFileHandling = DuplicateFileHandling.ThrowError

        )
    {
        if (file != null)
        {
            if (dupeFileHandling == DuplicateFileHandling.ThrowError)
            {
                var fullPath = pathData.FullPath;

                throw new Exception(fullPath);
            }
        }
        file ??= new Domain.MediaFile()
        {

        };
        file.Name = pathData.FileName;
        file.Extension = pathData.Extension;
        file.MimeType = pathData.MimeType;

        file.MediaType = _mediaTypeResolver.GetMediaType(file.Extension);

        //&& file.MediaType == MediaType.Image
        if (inStream != null && inStream.Length > 0 && file.MediaType == MediaType.Image)
        {
            var image = await ProcessImage(file, inStream);
            file.Width = image.Width;
            file.Height = image.Height;
            file.Size = image.InStream.Length;

            return (image, file);
        }
        else
        {
            throw new Exception();
        }
    }
    private async Task<IImage> ProcessImage(Domain.MediaFile file, Stream inStream)
    {

        var originalSize = Size.Empty;

        var maxSize = 1024;

        _ = file.Extension;
        IImage outImage;

        if (originalSize.IsEmpty || originalSize.Width <= maxSize && originalSize.Height <= maxSize)
        {
            outImage = new ImageWrapper(inStream, originalSize);
            return outImage;
        }
        return new ImageWrapper();

    }
}
