using MVC_ViewModels_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ViewModels_Data.Models
{
    public class LanguageViewModel
    {
        public List<Language> List { get; set; }
        public List<Person> Peoples { get; set; }
        public List<LanguagePeople> LanguagePeoples { get; set; }
        public CreateLanguageViewModel CreateLanguageViewModel { get; set; }
        public CreateLanguagePeopleViewModel CreateLanguagePeopleViewModel { get; set; }
    }
}
