using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CVApp.ViewModels
{
    public class CreateCVViewModel
    {
        [Required(ErrorMessage = "Enter your first name")]
        [DataType(DataType.Text), Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Enter your last name")]
        [DataType(DataType.Text), Display(Name = "Last Name")]
        public String LastName { get; set; }

        [DataType(DataType.Date), Display(Name = "Date")]
        public DateTime date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Specify your Gender")]
        [Display(Name = "Sex: ")]
        public char GenderRadio { get; set; }

        [Display(Name = "Skills: ")]
        public List<string> SkillsChecked { get; set; }

        [Required(ErrorMessage = "Your email is required")]
        [DataType(DataType.Text), Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "File: ")]
        public IFormFile FormFile { get; set; }
    }
}
