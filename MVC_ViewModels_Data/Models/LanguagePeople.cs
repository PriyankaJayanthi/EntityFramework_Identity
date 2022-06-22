using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ViewModels_Data.Models
{
    public class LanguagePeople
    {
        public int LanguageID { get; set; }
        public Language Language { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
