using Blog.Domen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.EfDataAccess.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(r => r.Name).IsRequired().HasMaxLength(20);

            builder.Property(r => r.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasMany(r => r.Users).WithOne(u => u.Role).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
