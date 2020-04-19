using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MyApp.Namespace
{
    public class RegistracijaModel : PageModel
    {

        private readonly ILogger<RegistracijaModel> _logger;

        public RegistracijaModel(ILogger<RegistracijaModel> logger)
        {
            _logger = logger;
        }


        public void OnGet()
        {
        }
    }
}
