namespace PNN.File;
public class MediaType : IEquatable<MediaType>
{

    private readonly static IDictionary<string, string[]> _defaultExtensionsMap = new Dictionary<string, string[]>
    {
        ["image"] = new[] { "png", "jpg", "jpeg", "jfif", "gif", "webp", "bmp", "svg", "ico" },
        ["video"] = new[] { "mp4", "m4v", "mkv", "wmv", "avi", "asf", "mpg", "mpeg", "webm", "flv", "ogv", "mov", "3gp" },
        ["audio"] = new[] { "mp3", "wav", "wma", "aac", "flac", "oga", "m4a", "ogg" },
        ["document"] = new[] { "pdf", "doc", "docx", "ppt", "pptx", "pps", "ppsx", "docm", "odt", "ods", "dot", "dotx", "dotm", "psd", "xls", "xlsx", "rtf" },
        ["text"] = new[] { "txt", "xml", "csv", "htm", "html", "json", "css", "js" },
        ["bin"] = Array.Empty<string>()
    };

    private readonly static IDictionary<string, MediaType> _map = new Dictionary<string, MediaType>(StringComparer.OrdinalIgnoreCase);

    public readonly static MediaType Image = new("image", _defaultExtensionsMap["image"]);
    public readonly static MediaType Video = new("video", _defaultExtensionsMap["video"]);
    public readonly static MediaType Audio = new("audio", _defaultExtensionsMap["audio"]);
    public readonly static MediaType Document = new("document", _defaultExtensionsMap["document"]);
    public readonly static MediaType Text = new("text", _defaultExtensionsMap["text"]);
    public readonly static MediaType Binary = new("bin", _defaultExtensionsMap["bin"]);

    public MediaType(string name, params string[] defaultsExtension)
    {
        Name = name;
        DefaultExtensions = defaultsExtension;
        _map[name] = this;
    }

    public string Name { get; private set; }
    public string[] DefaultExtensions { get; private set; }
    public static IEnumerable<string> AllExtensions => _defaultExtensionsMap.Select(x => x.Key);
    public override string ToString() => Name;
    public static implicit operator string(MediaType obj)
           => obj?.Name;
    public static MediaType GetMediaType(string name)
    {
        if (name == null)
        {
            return null;
        }

        if (_map.TryGetValue(name, out var instance))
        {
            return instance;
        }

        return null;
    }

    public bool Equals(MediaType? other) => string.Equals(Name, other.Name);
}
