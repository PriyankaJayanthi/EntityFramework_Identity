using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_ViewModels_Data.Controllers;

namespace MVC_ViewModels_Data.Models

{
   public interface IPeopleRepo
    {
        public Person Create(string Name, string ContactNumber, int City);
        public List<Person> Read();
        public List<City> GetCityList();
        public Person Read(int id);
        public Person Update(Person person);
        public bool Delete(Person person);
    }
}