namespace PNN.File.Domain;
public class MediaFile
{
    public int Id { get; set; }
    public int FolderId { get; set; }
    public string Name { get; set; }
    public string Extension { get; set; }
    public string MimeType { get; set; }
    public int Size { get; set; }
    public int FixedSize { get; set; }
    public string MetaData { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public bool Deleted { get; set; }
    public int Version { get; set; }
    public int MediaStorageId { get; set; }
    public virtual MediaFolder MediaFolder { get; set; }
}
