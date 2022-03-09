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
    public class GuideMap : IEntityTypeConfiguration<Guide>
    {
        public void Configure(EntityTypeBuilder<Guide> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Id).ValueGeneratedOnAdd();
            builder.Property(g => g.Name).HasMaxLength(100);
            builder.Property(g => g.Name).IsRequired();
            builder.Property(g => g.Description).HasMaxLength(300);
            builder.Property(g => g.Description).IsRequired();
            builder.Property(g => g.Image).HasMaxLength(250);
            builder.Property(g => g.Image).IsRequired();
            builder.Property(g => g.InstagramUrl).HasMaxLength(50);
            builder.Property(g => g.TwitterUrl).HasMaxLength(50);
            builder.Property(g => g.CreatedByName).IsRequired();
            builder.Property(g => g.CreatedByName).HasMaxLength(50);
            builder.Property(g => g.ModifiedByName).IsRequired();
            builder.Property(g => g.ModifiedByName).HasMaxLength(50);
            builder.Property(g => g.CreatedDate).IsRequired();
            builder.Property(g => g.ModifiedDate).IsRequired();
            builder.Property(g => g.IsActive).IsRequired();
            builder.Property(g => g.IsDeleted).IsRequired();
            builder.ToTable("Guides");
        }
    }
}
