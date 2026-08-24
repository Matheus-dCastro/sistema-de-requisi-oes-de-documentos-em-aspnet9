using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastruruty.Data;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.HasKey(d => d.DocumentId);
        builder.Property(d => d.Title).IsRequired();
        builder.Property(d => d.DocumentType).IsRequired();
        builder.Property(d => d.UserId).IsRequired();

        builder.HasOne(d => d.User)
              .WithMany()
              .HasForeignKey(d => d.UserId)
              .OnDelete(DeleteBehavior.Cascade);
    }
}