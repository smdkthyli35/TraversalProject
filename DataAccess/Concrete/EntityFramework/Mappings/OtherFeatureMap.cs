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
    public class OtherFeatureMap : IEntityTypeConfiguration<OtherFeature>
    {
        public void Configure(EntityTypeBuilder<OtherFeature> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.Title).HasMaxLength(100);
            builder.Property(o => o.Title).IsRequired();
            builder.Property(o => o.Description).HasMaxLength(300);
            builder.Property(o => o.Description).IsRequired();
            builder.Property(o => o.Image).HasMaxLength(250);
            builder.Property(o => o.Image).IsRequired();
            builder.Property(o => o.CreatedByName).IsRequired();
            builder.Property(o => o.CreatedByName).HasMaxLength(50);
            builder.Property(o => o.ModifiedByName).IsRequired();
            builder.Property(o => o.ModifiedByName).HasMaxLength(50);
            builder.Property(o => o.CreatedDate).IsRequired();
            builder.Property(o => o.ModifiedDate).IsRequired();
            builder.Property(o => o.IsActive).IsRequired();
            builder.Property(o => o.IsDeleted).IsRequired();
            builder.ToTable("OtherFeatures");
        }
    }
}
