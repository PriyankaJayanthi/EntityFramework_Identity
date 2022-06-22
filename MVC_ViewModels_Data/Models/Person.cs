using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_ViewModels_Data.Models
{
    public class Person
    { 

        [Required]
        [Key]
        public int PersonId { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(1)]
        public string Name { get; set; }

        [Range(10,12)]
        public string  ContactNumber { get; set; }

        [Required]
        [MaxLength(15)]
        [MinLength(1)]
        public int CityId { get; set; }
        [Required]
        public virtual City City { get; set; }
        
        public ICollection<LanguagePeople> LanguagePeople { get; set; }

        public Person(int PersonId, string Name, string ContactNumber, int City)
        {
            this.PersonId = PersonId;
            this.Name = Name;
            this.ContactNumber = ContactNumber;
            this.CityId = City;
        }
        public Person(string Name, string ContactNumber, int City)
        { 
            this.Name = Name;
            this.ContactNumber = ContactNumber;
            this.CityId = City;
        }

        public Person()
        {
        }
    }
}
