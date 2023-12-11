using System.Globalization;
using Microsoft.AspNetCore.Http;
using PNN.File.Abstraction;

namespace PNN.File.Services;
public class MediaUrlGenerator : IMediaUrlGenerator
{
    // const string _fallbackImagesRootPath = "images/";

    private readonly MediaSettings _mediaSettings;
    private readonly string _host;
    private readonly string _pathBase;
    private readonly string _fallbackImageFileName;
    private readonly string _processedImagesRootPath;
    private readonly IHttpContextAccessor _httpContextAccessor;


    public MediaUrlGenerator()
    {
        //_mediaSettings = new MediaSettings();
        //_processedImagesRootPath = "";

        //_httpContextAccessor = httpContextAccessor;
        //var httpContext = _httpContextAccessor.HttpContext;
        //string pathBase = "/";
        //var request = httpContext.Request;
        //pathBase = request.PathBase;
        //_host = string.Format(CultureInfo.InvariantCulture, "//{0}{1}", request.Host, pathBase);

        //_pathBase = pathBase;
        //;
    }
    public string GenerateUrl(MediaFileInfo file, QueryString query, string host = null, bool doFallback = true)
    {

        string path;

        // Build virtual path with pattern "media/{id}/{album}/{dir}/{NameWithExt}"
        if (file?.Path != null)
        {
            path = _processedImagesRootPath + file.Id.ToString(CultureInfo.InvariantCulture) + "/" + file.Path;
        }
        else if (doFallback)
        {
            path = _processedImagesRootPath + "0/" + _fallbackImageFileName;
        }
        else
        {
            return null;
        }
        if (host == null)
        {
            host = _host;
        }
        else if (host == string.Empty)
        {
            host = _pathBase;
        }


        var url = host;
        // Strip leading "/", the host/pathBase has this already
        if (path[0] == '/')
        {
            path = path[1..];
        }
        // Append media path
        url += path;


        // Append query to url
        if (query.HasValue)
        {
            url += query.ToString();
        }
        return url;
    }
}
