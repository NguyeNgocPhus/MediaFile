using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PNN.File.Databases.Configurations;
internal class MediaFileConfiguration : IEntityTypeConfiguration<Domain.MediaFile>
{
    public void Configure(EntityTypeBuilder<Domain.MediaFile> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Name).IsRequired().IsUnicode();

        builder.HasOne(c => c.MediaFolder)
            .WithMany(c => c.MediaFiles)
            .HasForeignKey(c => c.FolderId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.ToTable("MediaFiles");

    }
}
