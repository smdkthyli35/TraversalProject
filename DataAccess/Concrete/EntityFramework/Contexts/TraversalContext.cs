using DataAccess.Concrete.EntityFramework.Mappings;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class TraversalContext : DbContext
    {
        public TraversalContext(DbContextOptions<TraversalContext> options) : base(options)
        {

        }

        public TraversalContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AboutMap());
            modelBuilder.ApplyConfiguration(new AboutPostMap());
            modelBuilder.ApplyConfiguration(new ContactMap());
            modelBuilder.ApplyConfiguration(new DestinationMap());
            modelBuilder.ApplyConfiguration(new FeatureMap());
            modelBuilder.ApplyConfiguration(new GuideMap());
            modelBuilder.ApplyConfiguration(new NewsletterMap());
            modelBuilder.ApplyConfiguration(new OtherFeatureMap());
            modelBuilder.ApplyConfiguration(new SubAboutMap());
            modelBuilder.ApplyConfiguration(new TestimonialMap());
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutPost> AboutPosts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<OtherFeature> OtherFeatures { get; set; }
        public DbSet<SubAbout> SubAbouts { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}
