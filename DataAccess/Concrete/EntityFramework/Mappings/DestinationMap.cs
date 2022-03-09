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
    public class DestinationMap : IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Destination> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).ValueGeneratedOnAdd();
            builder.Property(d => d.City).HasMaxLength(100);
            builder.Property(d => d.City).IsRequired();
            builder.Property(d => d.DayNight).HasMaxLength(50);
            builder.Property(d => d.DayNight).IsRequired();
            builder.Property(d => d.Price).IsRequired();
            builder.Property(d => d.Image).HasMaxLength(250);
            builder.Property(d => d.Image).IsRequired();
            builder.Property(d => d.Description).HasColumnType("NVARCHAR(MAX)");
            builder.Property(d => d.Description).IsRequired();
            builder.Property(d => d.Capacity).IsRequired();
            builder.Property(d => d.CreatedByName).IsRequired();
            builder.Property(d => d.CreatedByName).HasMaxLength(50);
            builder.Property(d => d.ModifiedByName).IsRequired();
            builder.Property(d => d.ModifiedByName).HasMaxLength(50);
            builder.Property(d => d.CreatedDate).IsRequired();
            builder.Property(d => d.ModifiedDate).IsRequired();
            builder.Property(d => d.IsActive).IsRequired();
            builder.Property(d => d.IsDeleted).IsRequired();
            builder.ToTable("Destinations");
        }
    }
}
