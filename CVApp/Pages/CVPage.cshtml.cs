using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CVApp.Pages
{
    
    public class CVPageModel : PageModel
    {
        private readonly IWebHostEnvironment _hostingEnv;

        public CVPageModel(IWebHostEnvironment hostingEnv)
        {
            _hostingEnv = hostingEnv;
        }

        [BindProperty]
        [DataType(DataType.Text),Display(Name ="Verification")]
        public int verfication1 { get; set; }

        [DataType(DataType.Text)]
        [BindProperty]
        public int verfication2 { get; set; }

        [DataType(DataType.Text)]
        [BindProperty]
        public int verficationResult{ get; set; }

        [BindProperty]
        public InputModel input { get; set; }

        [Display(Name = "File: ")]
        [BindProperty]
        public IFormFile FormFile { get; set; }

        public IEnumerable<SelectListItem> Nationalities { get; set; } = new List<SelectListItem>{new SelectListItem{Value= "Lebanese", Text="Lebanese"},new SelectListItem{Value="other", Text="Other"}};
        
        public IEnumerable<SelectListItem> Skills { get; set; } =
            new List<SelectListItem>{
                new SelectListItem{Value="java", Text="Java"},
                new SelectListItem{Value="python", Text="Python"},
                new SelectListItem{Value="asp .net", Text="ASP .NET Core"}
            };
        
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var fileName = Path.GetFileName(FormFile.FileName);
            var filePath = Path.Combine(_hostingEnv.WebRootPath, "images\\", fileName);

            using (var fileSteam = new FileStream(filePath, FileMode.Create))
            {
                FormFile.CopyToAsync(fileSteam);
                input.FormImagePath = fileName;
            }
            if (verfication1 + verfication2 != verficationResult)
            {
                System.Diagnostics.Debug.WriteLine(verfication1.GetType());
                ModelState.AddModelError(string.Empty, "Verifiction error.");
            }
            if (!ModelState.IsValid) { return Page(); }
            
            return RedirectToPage("Summary",input);
        }
        public class InputModel
        {
            [Required(ErrorMessage = "Enter your first name")]
            [DataType(DataType.Text), Display(Name = "First Name")]
            public String FirstName { get; set; }

            [Required(ErrorMessage ="Enter your last name")]
            [DataType(DataType.Text), Display(Name = "Last Name")]
            public String LastName { get; set; }

            [DataType(DataType.Date), Display(Name = "Date")]
            public DateTime date { get; set; } = DateTime.Now;

            [Required]
            [DataType(DataType.Text), Display(Name = "Nationality")]
            public IEnumerable<string> SelectedNationalities { get; set; }

            [Required(ErrorMessage ="Specify your Gender")]
            [Display(Name = "Sex: ")]
            public String GenderRadio { get; set; }

            [Display(Name = "Skills: ")]
            public List<string> SkillsChecked { get; set; }
            
            [Required(ErrorMessage ="Your email is required")]
            [DataType(DataType.Text), Display(Name = "Email")]
            public String Email { get; set; }

            [Required(ErrorMessage ="Please confirm your email")]
            [Compare("Email", ErrorMessage = "Make sure that the email and the confirmation are the same.")]
            [DataType(DataType.Text), Display(Name = "Confirm Email")]
            public String EmailConfirmation { get; set; }

            [Required(ErrorMessage ="Enter your password")]
            [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W)).+$", ErrorMessage ="Password should contain numbers, symbols, and characters")]
            [DataType(DataType.Password), Display(Name = "Password")]
            public String Password { get; set; }

            
            public string FormImagePath { get; set; }
        }
    }
}
