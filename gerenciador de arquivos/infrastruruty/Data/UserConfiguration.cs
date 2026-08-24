 using Domain.Models;                                                                                                                                                                  
using Microsoft.EntityFrameworkCore;                                                                                                                                                  
using Microsoft.EntityFrameworkCore.Metadata.Builders;                                                                                                                                

namespace infrastruruty.Data;                                                                                                                                                         
public class UserConfiguration : IEntityTypeConfiguration<User>                                                                                                                       
{                                                                                                                                                                                     
    public void Configure(EntityTypeBuilder<User> builder)                                                                                                                            
    {                                                                                                                                                                                 
        builder.HasKey(u => u.UserId);                                                                                                                                                
        builder.Property(u => u.UserName).IsRequired().HasMaxLength(100);                                                                                                             
        builder.Property(u => u.PasswordHash).IsRequired();                                                                                                                           
        builder.Property(u => u.PasswordSalt).IsRequired();                                                                                                                           
    }                                                                                                                                                                                 
}                                                                                                                                                                                     
                        