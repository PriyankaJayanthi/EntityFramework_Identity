using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_ViewModels_Data.Models;
using MVC_ViewModels_Data.Controllers;

namespace MVC_ViewModels_Data
{
    public class PeopleViewModel : CreatePersonViewModel
    {
        public List<Person> PeopleListView { get; set; }

        public string FilterString { get; set; }

        public string SearchResultEmpty { get; set; }
        public static object FilterText { get; internal set; }
        public List<City> CityList { get; set; }

        public PeopleViewModel()
        {
            PeopleListView = new List<Person>();
        }

    }
}
