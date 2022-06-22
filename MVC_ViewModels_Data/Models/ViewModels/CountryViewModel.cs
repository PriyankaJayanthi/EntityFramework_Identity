using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ViewModels_Data.Models
{
    public class CountryViewModel
    {
        public List<Country> List { get; set; }
        public CreateCountryViewModel CreateCountryViewModel { get; set; }
    }
}
