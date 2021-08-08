using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CVApp.Data;
using System.ComponentModel.DataAnnotations;
using CVApp.Services;
using AutoMapper;
using CVApp.ViewModels;

namespace CVApp.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ICVRepository _repository;
        private readonly IMapper _mapper;
        public DetailsModel(ICVRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public DetailsViewModel detailsModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var CV = await _repository.GetCvByID(id);

            if (CV == null)
            {
                return NotFound();
            }
            detailsModel = _mapper.Map<DetailsViewModel>(CV);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {

            await _repository.DeleteCv(id);

            return RedirectToPage("./Index");
        }
    }
}
