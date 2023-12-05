namespace PNN.File.Abstraction;
public interface IMediaTypeResolver
{

    /// <summary>
    /// Parses and expands a given type filter, returning a distinct list of all suitable file extensions.
    /// </summary>
    /// <param name="typeFilter">A list of either file extensions and/or media type names, e.g.: [ "image", ".mp4", "audio", ".pdf" ]. Extensions must start with a dot.</param>
    /// <returns>All suitable file extensions.</returns>
    IEnumerable<string> ParseTypeFilter(string[] typeFilter);
}
