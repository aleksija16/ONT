using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekat_1.Model;

namespace Projekat_1
{
    public class JedanKvizModel : PageModel
    
    {
    

        public IActionResult OnGet(int id)
        {
           
            return Page();
        }
        
      
    }

}
