using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVC_ViewModels_Data.Models
{
    public class CreatePersonViewModel
    {
        [DataType(DataType.Text)]
        [StringLength(20, MinimumLength =1)]
        [Required(ErrorMessage = "* Please enter name"), MaxLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "* Please enter phonenumber"), MaxLength(30)]
        [Display(Name = "PhoneNumber")]
        public string ContactNumber { get; set; }


        [DataType(DataType.Text)]
        [Required(ErrorMessage = "* Please selecte city"), MaxLength(50)]
        [Display(Name = "City")]
        [StringLength(15,MinimumLength =1)]
        public int City { get; set; }
        public List<City> cities { get; set; }

        [Key]
        public int Id { get; set; }
        public CreatePersonViewModel()
        {

        }
    }

}
