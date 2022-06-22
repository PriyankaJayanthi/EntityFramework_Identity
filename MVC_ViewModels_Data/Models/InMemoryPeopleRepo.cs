using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ViewModels_Data.Models
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person> _personList = new List<Person>();
        private static List<City> _CityList = new List<City>();
        private static int _idCounter = 0;

        public Person Create(string Name, string PersonPhoneNumber, int PersonCity)
        {
            Person newPerson = new Person(_idCounter, Name, PersonPhoneNumber, PersonCity);
            _idCounter++;
            _personList.Add(newPerson);
            return newPerson;
        }

        public bool Delete(Person person)
        {
            bool delete = _personList.Remove(person);
            
            return delete;
        }

        public List<Person> Read()
        {
            return _personList;
        }

        public List<City> GetCityList()
        {
            return _CityList;
        }

        public Person Read(int id)
        {
            Person findPersonById = _personList.Find(idNr => idNr.PersonId == id);

            return findPersonById;
        }

        public Person Update(Person person)
        {
            foreach(Person item in _personList)
            {
                if(item.PersonId == person.PersonId)
                {
                    item.Name = person.Name;
                    item.ContactNumber = person.ContactNumber;
                    item.City = person.City;
                }
            }
            return person;
        }

    }
}
