using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MyApp.Namespace
{
    public class PrijavaModel : PageModel
    {

        private readonly ILogger<PrijavaModel> _logger;

        public PrijavaModel(ILogger<PrijavaModel> logger)
        {
            _logger = logger;
        }


        public void OnGet()
        {
        }
    }
}
