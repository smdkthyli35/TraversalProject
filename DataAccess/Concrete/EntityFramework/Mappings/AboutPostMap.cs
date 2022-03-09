using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class AboutPostMap : IEntityTypeConfiguration<AboutPost>
    {
        public void Configure(EntityTypeBuilder<AboutPost> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.FirstTitle).HasMaxLength(100);
            builder.Property(a => a.FirstTitle).IsRequired();
            builder.Property(a => a.SecondTitle).HasMaxLength(100);
            builder.Property(a => a.SecondTitle).IsRequired();
            builder.Property(a => a.Description).HasColumnType("NVARCHAR(MAX)");
            builder.Property(a => a.Description).IsRequired();
            builder.Property(a => a.Image).HasMaxLength(300);
            builder.Property(a => a.Image).IsRequired();
            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(50);
            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(50);
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedDate).IsRequired();
            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.ToTable("AboutPosts");
        }
    }
}
