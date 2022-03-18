using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.ViewComponents.Home
{
    public class _Feature : ViewComponent
    {
        private readonly IFeatureService _featureService;

        public _Feature(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var features = await _featureService.GetAllAsync();
            return View(new FeatureViewModel
            {
                Features = features.Data.Features
            });
        }
    }
}
