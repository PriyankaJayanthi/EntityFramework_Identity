using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ViewModels_Data.Models
{
    public class CityViewModel
    {
        public List<City> List { get; set; }
        public CreateCityViewmodel CreateCityViewModel { get; set; }
        public List<Country> Countrys { get; set; }
    }
}
