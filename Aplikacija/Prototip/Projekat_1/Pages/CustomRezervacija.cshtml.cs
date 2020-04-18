using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MyApp.Namespace
{
    public class CustomRezervacijaModel : PageModel
    {

        private readonly ILogger<CustomRezervacijaModel> _logger;

        public CustomRezervacijaModel(ILogger<CustomRezervacijaModel> logger)
        {
            _logger = logger;
        }

        
        public void OnGet()
        {
        }
    }
}
