using System;
using System.Collections.Generic;

namespace Projekat_1.Model
{
    public partial class Vodici
    {
        public Vodici()
        {
            Korisnici = new HashSet<Korisnici>();
        }

        public uint IdVodica { get; set; }
        public string ImeVodica { get; set; }
        public string PrezimeVodica { get; set; }
        public string Pol { get; set; }
        public string BrojTelefona { get; set; }

        public virtual ICollection<Korisnici> Korisnici { get; set; }
    }
}
