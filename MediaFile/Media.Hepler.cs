using PNN.File.Abstraction;

namespace PNN.File;
public class MediaHelper
{

    private readonly IFolderService _folderService;


    public MediaHelper(IFolderService folderService)
    {
        _folderService = folderService;
    }
    public bool TokenizePath(string path, bool normalizeName)
    {
        dynamic data = null;
        var normalizeNam1e = normalizeName;
        
        if (path == null)
        {
            return false;
        }
        var dir = Path.GetDirectoryName(path); /// /catalog/abc.jpg => /catalog
        if(dir != null)
        {
            return true;
        }
        return false;
    }
}
