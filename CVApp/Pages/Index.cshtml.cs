using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CVApp.Data;
using CVApp.Services;
using CVApp.ViewModels;
using AutoMapper;

namespace CVApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICVRepository _repository;
        private readonly IMapper _mapper;

        public IndexModel(ICVRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IList<IndexViewModel> ViewModel { get;set; }

        public async Task OnGetAsync()
        {
            var CV = await _repository.GetAllCVs();
            ViewModel = _mapper.Map<IList<IndexViewModel>>(CV);
        }
    }
}
