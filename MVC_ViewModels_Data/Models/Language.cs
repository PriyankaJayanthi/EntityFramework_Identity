using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_ViewModels_Data.Models
{
    public class Language
    {
        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LanguageID { get; set; }
        public string Name { get; set; }
        public ICollection<LanguagePeople> LanguagePeople { get; set; }
    }
}
