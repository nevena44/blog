using Blog.Domen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.EfDataAccess.Configurations
{
    public class PostHashtagConfiguration : IEntityTypeConfiguration<PostHashtag>
    {
        public void Configure(EntityTypeBuilder<PostHashtag> builder)
        {
            builder.HasKey(ph => new { ph.HashtagId, ph.PostId });

            builder.HasOne(ph => ph.Hashtag).WithMany(h => h.PostHashtags).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(ph => ph.Post).WithMany(p => p.PostHashtags).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
