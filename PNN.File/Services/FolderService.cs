using PNN.File.Abstraction;

namespace PNN.File.Services;
public class FolderService : IFolderService
{

    protected internal static string NormalizePath(string path, bool forQuery = true)
    {
        if (path.IndexOf('\\') > -1)
        {
            path = path.Replace('\\', '/');
        }

        var trim = path[0] == '/' || path.Length > 1 && path[^1] == '/';
        if (trim)
        {
            path = path.Trim('/');
        }

        return forQuery ? path.ToLower() : path;
    }
}
