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
    public class FeatureMap : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.Property(f => f.Title).HasMaxLength(100);
            builder.Property(f => f.Title).IsRequired();
            builder.Property(f => f.Description).HasColumnType("NVARCHAR(MAX)");
            builder.Property(f => f.Description).IsRequired();
            builder.Property(f => f.Image).HasMaxLength(250);
            builder.Property(f => f.Image).IsRequired();
            builder.Property(f => f.CreatedByName).IsRequired();
            builder.Property(f => f.CreatedByName).HasMaxLength(50);
            builder.Property(f => f.ModifiedByName).IsRequired();
            builder.Property(f => f.ModifiedByName).HasMaxLength(50);
            builder.Property(f => f.CreatedDate).IsRequired();
            builder.Property(f => f.ModifiedDate).IsRequired();
            builder.Property(f => f.IsActive).IsRequired();
            builder.Property(f => f.IsDeleted).IsRequired();
            builder.ToTable("Features");
        }
    }
}
