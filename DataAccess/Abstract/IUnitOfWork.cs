using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IAboutDal Abouts { get; }
        IAboutPostDal AboutPosts { get; }
        IContactDal Contacts { get; }
        IDestinationDal Destinations { get; }
        IFeatureDal Features { get; }
        IGuideDal Guides { get; }
        INewsletterDal Newsletters { get; }
        IOtherFeatureDal OtherFeatures { get; }
        ISubAboutDal SubAbouts { get; }
        ITestimonialDal Testimonials { get; }

        Task<int> SaveAsync();
    }
}
