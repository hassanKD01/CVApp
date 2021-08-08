using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CVApp.Data;
using CVApp.Services;
using CVApp.ViewModels;
using AutoMapper;

namespace CVApp.Pages
{
    public class EditModel : PageModel
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

        public EditModel(ImageServices imageServices, ICVRepository repository, IMapper mapper)
        {
            _imageservices = imageServices;
            _repository = repository;
            _mapper = mapper;
        }

        [BindProperty]
        public UpdateViewModel CVinput { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            CV cv = await _repository.GetCvByID(id);

            if (cv == null)
            {
                return NotFound();
            }

            CVinput = _mapper.Map<UpdateViewModel>(cv);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string imageName;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (CVinput.FormFile != null)
            {
                imageName = await _imageservices.SavePicture(CVinput.FormFile);
            }
            else imageName = CVinput.ImageName;

            var cv = _mapper.Map<CV>(CVinput);
            cv.ImageName = imageName;

            bool updated = await _repository.UpdateCv(cv);

            if (!updated) return NotFound();

            return RedirectToPage("./Index");
        }
    }
}
