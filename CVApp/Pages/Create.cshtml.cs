using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CVApp.Data;
using CVApp.Services;
using CVApp.ViewModels;
using AutoMapper;
using System.Diagnostics;

namespace CVApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ICVRepository _repository;
        private readonly ImageServices _imageservices;
        private readonly IMapper _mapper;

        public IEnumerable<SelectListItem> Skills { get; set; } =
            new List<SelectListItem>{
                new SelectListItem{Value="java", Text="Java"},
                new SelectListItem{Value="python", Text="Python"},
                new SelectListItem{Value="asp .net", Text="ASP .NET Core"}
            };

        public CreateModel(ImageServices imageServices, ICVRepository repository, IMapper mapper)
        {
            _imageservices = imageServices;
            _repository = repository;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CreateCVViewModel CVinput { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string imageName;
            if (CVinput.FormFile != null)
            {
                imageName = await _imageservices.SavePicture(CVinput.FormFile);
            }
            else imageName = CVinput.GenderRadio == 'f'? "default-no-profile-pic-girl.jpg": "default-no-profile-pic.jpg"; 

            var CV = _mapper.Map<CV>(CVinput);
            CV.ImageName = imageName;
            
            await _repository.CreateCV(CV);

            return RedirectToPage("./Index");
        }
    }
}
