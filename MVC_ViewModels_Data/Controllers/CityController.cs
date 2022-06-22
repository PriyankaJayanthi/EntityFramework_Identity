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
    public class CityController : Controller
    {
        public CityViewModel cityViewmodel = new CityViewModel();

        ExDbContext _context;

        public CityController(ExDbContext context)
        {
            _context = context;
            cityViewmodel.Countrys = _context.countries.ToList();
        }

        public IActionResult Index()
        {
            List<City> cities = _context.cities.Include(i => i.Peoples).Include(i => i.Country).ToList();
            cityViewmodel.List = cities;
            return View(cityViewmodel);
        }
    }
}
