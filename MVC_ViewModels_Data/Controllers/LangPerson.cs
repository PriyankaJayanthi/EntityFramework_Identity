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
    public class LangPerson : Controller
    {
        private readonly ExDbContext Context;
        public LanguageViewModel vm = new LanguageViewModel();
        public LangPerson(ExDbContext context)
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
        public IActionResult BindLanguagePeople(LanguageViewModel languageViewModel)
        {
            CreateLanguagePeopleViewModel LanguagePeople = languageViewModel.CreateLanguagePeopleViewModel;
            if (ModelState.IsValid)
            {
                LanguagePeople newLanguagePeople = new LanguagePeople { PersonId = (int)LanguagePeople.People, LanguageID = (int)LanguagePeople.Language };
                Context.LanguagePeople.Add(newLanguagePeople);
                Context.SaveChanges();
            }
            vm.Peoples = Context.Person.ToList();
            vm.List = Context.Language.ToList();
            vm.LanguagePeoples = Context.LanguagePeople.Include(e => e.Language).Include(e => e.Person).ToList();
            return View(vm);
        }
    }
}
