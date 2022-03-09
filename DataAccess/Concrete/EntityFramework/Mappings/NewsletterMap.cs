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
    public class NewsletterMap : IEntityTypeConfiguration<Newsletter>
    {
        public void Configure(EntityTypeBuilder<Newsletter> builder)
        {
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Id).ValueGeneratedOnAdd();
            builder.Property(n => n.Mail).HasMaxLength(100);
            builder.Property(n => n.Mail).IsRequired();
            builder.Property(n => n.CreatedByName).IsRequired();
            builder.Property(n => n.CreatedByName).HasMaxLength(50);
            builder.Property(n => n.ModifiedByName).IsRequired();
            builder.Property(n => n.ModifiedByName).HasMaxLength(50);
            builder.Property(n => n.CreatedDate).IsRequired();
            builder.Property(n => n.ModifiedDate).IsRequired();
            builder.Property(n => n.IsActive).IsRequired();
            builder.Property(n => n.IsDeleted).IsRequired();
            builder.ToTable("Newsletters");
        }
    }
}
