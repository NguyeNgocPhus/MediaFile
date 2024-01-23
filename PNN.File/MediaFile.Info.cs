using Microsoft.AspNetCore.Http;
using System.Globalization;
using System;
using PNN.File.Abstraction;

namespace PNN.File;
public class MediaFileInfo
{
    private readonly IMediaUrlGenerator _mediaUrlGenerator;
    public MediaFileInfo(IMediaUrlGenerator mediaUrlGenerator)
    {
        _mediaUrlGenerator = mediaUrlGenerator;
    }

    public Domain.MediaFile File { get;private set; }
    public int Id => File.Id;
    public int? FolderId => File.FolderId;
    public string MimeType=> File.MimeType;
    public string MediaType => File.MimeType;
    public bool Deleted => File.Deleted;
    public DateTimeOffset CreatedOn => File.CreatedAt;
    public string Path { get; private set; }

    public string Url { get; set; }
    internal string ThumbUrl => GetUrl(ThumbSize, string.Empty);
    internal int ThumbSize
    {
        // For serialization of "ThumbUrl" in MediaManager
        get; set;
    } = 256;
    public string GetUrl(int maxSize = 0 , string host =null)
    {
        var query = maxSize > 0
                    ? QueryString.Create("size", maxSize.ToString(CultureInfo.InvariantCulture))
                    : QueryString.Empty;

        return _mediaUrlGenerator.GenerateUrl(this, query, host, false);
    }

    public bool Exists => File.Id > 0;
    public DateTimeOffset LastModified => File.UpdatedAt;
    public long Length => File.Size;
    public string Name => File.Name;
    string PhysicalPath => Path;

}
