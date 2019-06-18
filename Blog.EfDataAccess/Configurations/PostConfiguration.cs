using Blog.Domen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.EfDataAccess.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.Title).IsRequired();

            builder.Property(p => p.SubTitle).IsRequired();

            builder.Property(p => p.Description).IsRequired();

            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasMany(p => p.Comments).WithOne(c => c.Post).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.User).WithMany(u => u.Posts).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Picture).WithMany(pc => pc.Posts).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.PostHashtags).WithOne(ph => ph.Post).HasForeignKey(ph => ph.PostId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
