using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_ViewModels_Data.Models;

namespace MVC_ViewModels_Data.Models
{
    public class PeopleService : IPeopleService
    {

        IPeopleRepo _peopleRepo;
        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }

        public Person Add(CreatePersonViewModel person)
        {
            return _peopleRepo.Create(person.Name, person.ContactNumber, person.City);
        }

        public PeopleViewModel All()
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel();

            peopleViewModel.PeopleListView = _peopleRepo.Read();
            peopleViewModel.CityList = _peopleRepo.GetCityList();

            return peopleViewModel;
        }

        public PeopleViewModel CityList()
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel();

            peopleViewModel.CityList = _peopleRepo.GetCityList();

            return peopleViewModel;
        }

        public Person Edit(int id, Person person)
        {
            return _peopleRepo.Update(person);
        }

        public PeopleViewModel FindBy(PeopleViewModel search)
        {

            List<Person> searchedPersonList = new List<Person>();

            foreach (Person item in _peopleRepo.Read())
            {
                if (item.Name.Contains(search.FilterString, StringComparison.OrdinalIgnoreCase))
                {
                    searchedPersonList.Add(item);
                }
            }
            search.PeopleListView = searchedPersonList;

            return search;
        }

        public Person FindBy(int id)
        {
            return _peopleRepo.Read(id);
        }

        public bool Remove(int id)
        {
            List<Person> listPersons = _peopleRepo.Read();
            bool deleted = false;

            foreach (Person item in listPersons)
            {
                if (item.PersonId == id)
                {
                    return _peopleRepo.Delete(item);
                }
            }

            return deleted;
        }

    }
}
