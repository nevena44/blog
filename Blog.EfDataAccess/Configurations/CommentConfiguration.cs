using Blog.Domen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.EfDataAccess.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.Description).IsRequired();

            builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasOne(c => c.User).WithMany(u => u.Comments).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Post).WithMany(p => p.Comments).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
