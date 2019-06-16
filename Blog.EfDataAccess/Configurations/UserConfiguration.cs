using Blog.Domen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.EfDataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(20);

            builder.Property(u => u.LastName).IsRequired().HasMaxLength(30);

            builder.Property(u => u.Username).IsRequired().HasMaxLength(20);
            builder.HasIndex(u => u.Username).IsUnique();

            builder.Property(u => u.Email).IsRequired();

            builder.Property(u => u.Password).IsRequired().HasMaxLength(10);

            builder.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasOne(u => u.Role).WithMany(r => r.Users).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(u => u.Comments).WithOne(c => c.User).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(u => u.Posts).WithOne(p => p.User).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
