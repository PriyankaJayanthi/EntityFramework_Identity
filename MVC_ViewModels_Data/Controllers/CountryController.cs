using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_ViewModels_Data.Data;
using MVC_ViewModels_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ViewModels_Data.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CountryController : Controller
    {
        public CountryViewModel countryViewModel = new CountryViewModel();

        ExDbContext _context;

        public CountryController(ExDbContext context)
        {
            _context = context;
        }
        private ExDbContext Context { get; }
        public IActionResult Index()
        {
            List<Country> countrys = _context.countries.Include(i => i.Cities).ToList();
            countryViewModel.List = countrys;
            return View(countryViewModel);
        }
    }
}
