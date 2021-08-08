using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CVApp.Pages
{
    public class SummaryModel : PageModel
    {

        public CVPageModel.InputModel Input;
        public void OnGet(CVPageModel.InputModel Input)
        {
            this.Input = Input;
        }
        
    }
}
