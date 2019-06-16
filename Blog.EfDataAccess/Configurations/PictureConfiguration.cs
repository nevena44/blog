using Blog.Domen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.EfDataAccess.Configurations
{
    public class PictureConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.Property(p => p.Src).IsRequired();

            builder.Property(p => p.Alt).IsRequired().HasMaxLength(30);

            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasOne(p => p.Post).WithMany(ps => ps.Pictures).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
