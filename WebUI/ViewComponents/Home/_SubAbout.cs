using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.ViewComponents.Home
{
    public class _SubAbout : ViewComponent
    {
        private readonly ISubAboutService _subAboutService;

        public _SubAbout(ISubAboutService subAboutService)
        {
            _subAboutService = subAboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var subAbout = await _subAboutService.GetAllAsync();
            return View(new SubAboutViewModel
            {
                SubAbouts = subAbout.Data.SubAbouts
            });
        }
    }
}
