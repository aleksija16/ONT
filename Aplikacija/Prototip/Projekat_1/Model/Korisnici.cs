using System;
using System.Collections.Generic;

namespace Projekat_1.Model
{
    public partial class Korisnici
    {
        public uint Idkorisnika { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual Turisti Turisti { get; set; }
        public virtual Vodici Vodici { get; set; }
    }
}
