using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CVApp.Data;

namespace CVApp.ViewModels
{
    public class DetailsViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [Display(Name = "Date of birth")]
        public string BirthDate { get; set; }
        public string Gender { get; set; }

        [Display(Name = "Skills")]
        public List<Skill> Skills { get; set; }
        public string Email { get; set; }
        public string ImageName { get; set; }
    }
}
