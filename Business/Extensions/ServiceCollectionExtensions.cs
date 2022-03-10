using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Concrete.EntityFramework.Repositories;
using Entities.Concrete;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TraversalContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("DataAccess")));
            services.AddScoped<DbContext>(provider => provider.GetService<TraversalContext>());

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAboutPostService, AboutPostManager>();
            services.AddScoped<IAboutPostDal, EfAboutPostDal>();

            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, EfAboutDal>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EfContactDal>();

            services.AddScoped<IDestinationService, DestinationManager>();
            services.AddScoped<IDestinationDal, EfDestinationDal>();

            services.AddScoped<IFeatureService, FeatureManager>();
            services.AddScoped<IFeatureDal, EfFeatureDal>();

            services.AddScoped<IGuideService, GuideManager>();
            services.AddScoped<IGuideDal, EfGuideDal>();

            services.AddScoped<INewsletterService, NewsletterManager>();
            services.AddScoped<INewsletterDal, EfNewsletterDal>();

            services.AddScoped<IOtherFeatureService, OtherFeatureManager>();
            services.AddScoped<IOtherFeatureDal, EfOtherFeatureDal>();

            services.AddScoped<ISubAboutService, SubAboutManager>();
            services.AddScoped<ISubAboutDal, EfSubAboutDal>();

            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<ITestimonialDal, EfTestimonialDal>();

            services.AddSingleton<IValidator<AboutPost>, AboutPostValidator>();
            services.AddSingleton<IValidator<About>, AboutValidator>();
            services.AddSingleton<IValidator<Contact>, ContactValidator>();
            services.AddSingleton<IValidator<Destination>, DestinationValidator>();
            services.AddSingleton<IValidator<Feature>, FeatureValidator>();
            services.AddSingleton<IValidator<Guide>, GuideValidator>();
            services.AddSingleton<IValidator<Newsletter>, NewsletterValidator>();
            services.AddSingleton<IValidator<OtherFeature>, OtherFeatureValidator>();
            services.AddSingleton<IValidator<SubAbout>, SubAboutValidator>();
            services.AddSingleton<IValidator<Testimonial>, TestimonialValidator>();

            return services;
        }
    }
}
