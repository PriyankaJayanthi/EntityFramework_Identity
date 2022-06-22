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
    public class LanguageController : Controller
    {
        private readonly ExDbContext Context;
        public LanguageViewModel vm = new LanguageViewModel();
        public LanguageController(ExDbContext context)
        {
            Context = context;

        }
        public IActionResult Index()
        {
            vm.Peoples = Context.Person.ToList();
            vm.List = Context.Language.ToList();
            vm.LanguagePeoples = Context.LanguagePeople.Include(e => e.Language).Include(e => e.Person).ToList();
            return View(vm);
        }
        [HttpPost]
        public IActionResult Index(LanguageViewModel languageViewModel)
        {
            CreateLanguageViewModel Language = languageViewModel.CreateLanguageViewModel;
            if (ModelState.IsValid)
            {
                Language newLanguage = new Language { Name = Language.Name };
                Context.Language.Add(newLanguage);
                Context.SaveChanges();
            }
            vm.Peoples = Context.Person.ToList();
            vm.List = Context.Language.ToList();
            vm.LanguagePeoples = Context.LanguagePeople.Include(e => e.Language).Include(e => e.Person).ToList();
            return View(vm);
        }
    }
}
