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
    public class TestimonialMap : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Property(t => t.Client).HasMaxLength(200);
            builder.Property(t => t.Client).IsRequired();
            builder.Property(t => t.Comment).HasMaxLength(500);
            builder.Property(t => t.Comment).IsRequired();
            builder.Property(t => t.ClientImage).HasMaxLength(250);
            builder.Property(t => t.ClientImage).IsRequired();
            builder.Property(t => t.CreatedByName).IsRequired();
            builder.Property(t => t.CreatedByName).HasMaxLength(50);
            builder.Property(t => t.ModifiedByName).IsRequired();
            builder.Property(t => t.ModifiedByName).HasMaxLength(50);
            builder.Property(t => t.CreatedDate).IsRequired();
            builder.Property(t => t.ModifiedDate).IsRequired();
            builder.Property(t => t.IsActive).IsRequired();
            builder.Property(t => t.IsDeleted).IsRequired();
            builder.ToTable("Testimonials");
        }
    }
}
