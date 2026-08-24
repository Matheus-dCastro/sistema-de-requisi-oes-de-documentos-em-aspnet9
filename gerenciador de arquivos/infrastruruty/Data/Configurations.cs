using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace infrastruruty.Data;

public class Configurations
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserName).IsRequired();
                entity.Property(e => e.Passwolrd).IsRequired();
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.DocumentId);
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.DocumentType).IsRequired();
                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                      .WithMany()
                      .HasForeignKey(d => d.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }