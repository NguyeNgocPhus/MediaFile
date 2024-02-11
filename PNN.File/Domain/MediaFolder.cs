namespace PNN.File.Domain;
public class MediaFolder
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public string Name { get; set; }
    public int FilesCount { get; set; }
    public virtual IEnumerable<MediaFile> MediaFiles { get; set; }

}
