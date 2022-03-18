using Business.Abstract;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.ViewComponents.Home
{
    public class _Statistics : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public _Statistics(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.destination = await _unitOfWork.Destinations.CountAsync();
            ViewBag.guide = await _unitOfWork.Guides.CountAsync();
            ViewBag.customer = "285";
            return View();
        }
    }
}
