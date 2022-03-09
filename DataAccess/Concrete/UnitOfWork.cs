using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TraversalContext _context;

        private EfAboutDal _aboutDal;
        private EfAboutPostDal _aboutPostDal;
        private EfContactDal _contactDal;
        private EfDestinationDal _destinationDal;
        private EfFeatureDal _featureDal;
        private EfGuideDal _guideDal;
        private EfNewsletterDal _newsletterDal;
        private EfOtherFeatureDal _otherFeatureDal;
        private EfSubAboutDal _subAboutDal;
        private EfTestimonialDal _testimonialDal;

        public UnitOfWork(TraversalContext context)
        {
            _context = context;
        }

        public IAboutDal Abouts => _aboutDal = _aboutDal ?? new EfAboutDal(_context);

        public IAboutPostDal AboutPosts => _aboutPostDal = _aboutPostDal ?? new EfAboutPostDal(_context);

        public IContactDal Contacts => _contactDal = _contactDal ?? new EfContactDal(_context);

        public IDestinationDal Destinations => _destinationDal = _destinationDal ?? new EfDestinationDal(_context);

        public IFeatureDal Features => _featureDal = _featureDal ?? new EfFeatureDal(_context);

        public IGuideDal Guides => _guideDal = _guideDal ?? new EfGuideDal(_context);

        public INewsletterDal Newsletters => _newsletterDal = _newsletterDal ?? new EfNewsletterDal(_context);

        public IOtherFeatureDal OtherFeatures => _otherFeatureDal = _otherFeatureDal ?? new EfOtherFeatureDal(_context);

        public ISubAboutDal SubAbouts => _subAboutDal = _subAboutDal ?? new EfSubAboutDal(_context);

        public ITestimonialDal Testimonials => _testimonialDal = _testimonialDal ?? new EfTestimonialDal(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
