using System;
using System.Collections.Generic;

namespace KonacniProjekat.Models
{
    public partial class Anketa
    {
        public uint IdAnkete { get; set; }
        public uint IdTuristeAnk { get; set; }
        public uint? IdTureAnk { get; set; }
        public uint? IdVodicaAnk { get; set; }
        public uint? KonacnaOcena { get; set; }
        public string VremenskiUslovi { get; set; }
        public string Komentar { get; set; }
        public uint? OrganizovanostTure { get; set; }
        public uint? InformisanostVodica { get; set; }
        public uint? FizickaZahtevnostTure { get; set; }
        public string TipTuriste { get; set; }
        public string DrustvenaAtmosfera { get; set; }
        public string NajinteresantnijaZnamenitost { get; set; }
        public string NajdosadnijaZnamenitost { get; set; }

        public virtual Ture IdTureAnkNavigation { get; set; }
        public virtual Turisti IdTuristeAnkNavigation { get; set; }
        public virtual Vodici IdVodicaAnkNavigation { get; set; }
    }
}
