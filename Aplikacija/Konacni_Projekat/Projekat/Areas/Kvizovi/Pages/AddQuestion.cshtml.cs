using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat.Models;

namespace Projekat.Areas.Kvizovi
{
    public class AddQuestionModel : PageModel
    {
        [BindProperty]
        public int? SessionId {get; set;}
        public readonly OrganizacijaContext dbContext;

         public AddQuestionModel(OrganizacijaContext db)
        {
            dbContext = db;
            SessionId = null;
        }
        public void OnGet()
        {
        }
    }
}