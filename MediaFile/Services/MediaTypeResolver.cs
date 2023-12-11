using PNN.File.Abstraction;

namespace PNN.File.Services;
public class MediaTypeResolver : IMediaTypeResolver
{
    public MediaTypeResolver()
    {

    }
    public IEnumerable<string> ParseTypeFilter(string[] typeFilter)
    {
        if (typeFilter.Length == 0 || typeFilter == null)
        {
            return Enumerable.Empty<string>();
        }
        var extensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var type in typeFilter)
        {
            if (typeFilter[0] == ".")
            {
                extensions.Add(type[1..]);
            }
            else
            {
                return GetExtensionMediaTypeMap().Where(x => x.Value == type).Select(x => x.Key);
            }
        }
        return extensions;
    }
    public IReadOnlyDictionary<string, string> GetExtensionMediaTypeMap()
    {
        var map = new Dictionary<string, string>();

        AddExtensionsToMap(MediaType.Image);
        AddExtensionsToMap(MediaType.Video);
        AddExtensionsToMap(MediaType.Audio);
        AddExtensionsToMap(MediaType.Text);
        AddExtensionsToMap(MediaType.Document);

        return map;
        void AddExtensionsToMap(MediaType media)
        {

            foreach (var ext in media.DefaultExtensions)
            {
                map.Add( ext, media.Name);
            }
        }

    }
}
