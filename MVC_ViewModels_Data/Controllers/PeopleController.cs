using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_ViewModels_Data.Models;
using MVC_ViewModels_Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MVC_ViewModels_Data.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class PeopleController : Controller
    {
        IPeopleService _peopleService;
        ExDbContext _context;
        IPeopleRepo _peopleRepo;

        public PeopleController(IPeopleService peopleService, ExDbContext context, IPeopleRepo peopleRepo)
        {
            _peopleService = peopleService;
            _context = context;
            _peopleRepo = peopleRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Person> people = _context.Person.Include(i => i.City).ToList();
           
            return View(_peopleService.All());
        }


       [HttpPost]
        public IActionResult Index(string FilterString)
        {
            var searchperson = from m in _context.Person
                         select m;

            if (!String.IsNullOrEmpty(FilterString))
            {
                searchperson = searchperson.Where(s => s.Name!.Contains(FilterString));
            }
            var peopleViewModel = new PeopleViewModel
            {
                CityList = _peopleRepo.GetCityList(),
                PeopleListView =  searchperson.ToList()
            };
            List<Person> people = _context.Person.Include(i => i.City).ToList();
            return View(peopleViewModel);
        }


        [HttpGet]
        public IActionResult CreatePerson()
        {
            List<City> List = _context.cities.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel personViewModel)
        {
                 
                _peopleService.Add(personViewModel);
                return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeletePerson(int id)
        {
            _peopleService.Remove(id);

            return RedirectToAction(nameof(Index));
        }
    

    }
}
