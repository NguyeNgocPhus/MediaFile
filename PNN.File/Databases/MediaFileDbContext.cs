using Microsoft.EntityFrameworkCore;
using PNN.File.Databases.Configurations;
using PNN.File.Domain;

namespace PNN.File.Databases;
public class MediaFileDbContext : DbContext
{
    public MediaFileDbContext(DbContextOptions<MediaFileDbContext> options) : base(options)
    {

    }
    public DbSet<Domain.MediaFile> MediaFiles { get; set; }
    public DbSet<MediaFolder> MediaFolders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MediaFileConfiguration());
        modelBuilder.ApplyConfiguration(new MediaFolderConfiguration());
    }

}
