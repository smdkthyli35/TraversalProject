using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.ViewComponents.Home
{
    public class _Testimonial : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public _Testimonial(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var testimonials = await _testimonialService.GetAllAsync();
            return View(new TestimonialViewModel
            {
                Testimonials = testimonials.Data.Testimonials
            });
        }
    }
}
