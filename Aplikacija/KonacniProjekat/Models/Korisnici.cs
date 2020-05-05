using System;
using System.Collections.Generic;

namespace KonacniProjekat.Models
{
    public partial class Korisnici
    {
        public uint IdKorisnika { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string TipKorisnika { get; set; }
        public uint? IdVodicaK { get; set; }
        public uint? IdTuristeK { get; set; }

        public virtual Turisti IdTuristeKNavigation { get; set; }
        public virtual Vodici IdVodicaKNavigation { get; set; }
    }
}
