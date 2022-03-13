using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.ViewComponents.Home
{
    public class _PopularDestinations : ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _PopularDestinations(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var destinations = await _destinationService.GetAllAsync();
            return View(new PopularDestinationsViewModel
            {
                Destinations = destinations.Data.Destinations
            });
        }
    }
}
