using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Projekat.Models;

namespace Projekat.Pages
{
    public class IndexModel : PageModel
    {
        public uint? SessionId {get; set;}

        private readonly ILogger<IndexModel> _logger;

        private readonly OrganizacijaContext dbContext;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            SessionId = null;
        }

        public void OnGet()
        {

        }
    }
}
