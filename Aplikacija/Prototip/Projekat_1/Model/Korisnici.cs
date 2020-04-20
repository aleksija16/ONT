using System;
using System.Collections.Generic;

namespace Projekat_1.Model
{
    public partial class Korisnici
    {
        public uint IdKorisnika { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public uint? IdTuristeKor { get; set; }
        public uint? IdVodicaKor { get; set; }

        public virtual Turisti IdTuristeKorNavigation { get; set; }
        public virtual Vodici IdVodicaKorNavigation { get; set; }
    }
}
