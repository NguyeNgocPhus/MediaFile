namespace PNN.File.Exceptions;
public class DuplicateMediaFileException : Exception
{
    public DuplicateMediaFileException(string message, MediaFileInfo mediaInfo, string uniquePath) : base(message)
    {
        UniquePath = uniquePath;
        MediaFileInfo = mediaInfo;
    }

    public MediaFileInfo MediaFileInfo { get; }
    public string UniquePath { get; }

}
