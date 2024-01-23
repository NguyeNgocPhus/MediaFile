namespace PNN.File.Domain;
public class MediaFolder
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public string TreePath { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public bool CanDetectTracks { get; set; }
    public string MetaData { get; set; }
    public int FilesCount { get; set; }
    public string Discriminator { get; set; }
    public string ResKey { get; set; }
    public bool IncludePath { get; set; }

    public virtual IEnumerable<MediaFile> MediaFiles { get; set; }

}
