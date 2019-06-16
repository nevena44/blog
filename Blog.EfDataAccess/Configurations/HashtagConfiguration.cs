using Blog.Domen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.EfDataAccess.Configurations
{
    public class HashtagConfiguration : IEntityTypeConfiguration<Hashtag>
    {
        public void Configure(EntityTypeBuilder<Hashtag> builder)
        {
            builder.Property(h => h.Name).IsRequired().HasMaxLength(20);

            builder.Property(h => h.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasMany(h => h.PostHashtags).WithOne(ph => ph.Hashtag).HasForeignKey(ph => ph.HashtagId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
