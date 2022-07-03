using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_ViewModels_Data.Data;
using MVC_ViewModels_Data.Models;

namespace MVC_ViewModels_Data.Controllers
{
    public class AddCityController : Controller
    {
        private readonly ExDbContext _context;

        public AddCityController(ExDbContext context)
        {
            _context = context;
        }

        // GET: AddCity
        public async Task<IActionResult> Index()
        {
            var exDbContext = _context.cities.Include(c => c.Country);
            return View(await exDbContext.ToListAsync());
        }

        // GET: AddCity/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.cities
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.CityId == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: AddCity/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.countries, "CountryId", "Name");
            return View();
        }

        // POST: AddCity/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,CountryId")] City city)
        {
            if (ModelState.IsValid)
            {
                _context.Add(city);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.countries, "CountryId", "Name", city.CountryId);
            return View(city);
        }

        // GET: AddCity/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.countries, "CountryId", "Name", city.CountryId);
            return View(city);
        }

        // POST: AddCity/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,CountryId")] City city)
        {
            if (id != city.CityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.CityId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.countries, "CountryId", "Name", city.CountryId);
            return View(city);
        }

        // GET: AddCity/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.cities
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.CityId == id);
            if (city == null)
            {
                return NotFound();
            }
            else 
            {
                _context.cities.Remove(city);
                await _context.SaveChangesAsync();
            }

            return View(city);
        }

        private bool CityExists(int id)
        {
            return _context.cities.Any(e => e.CityId == id);
        }
    }
}
