using System;
using System.Collections.Generic;

namespace Projekat_1.Model
{
    public partial class Vodici
    {
        public uint Idvodica { get; set; }
        public string ImeVodica { get; set; }
        public string PrezimeVodica { get; set; }
        public string Pol { get; set; }
        public string BrojTelefona { get; set; }

        public virtual Korisnici IdvodicaNavigation { get; set; }
        public virtual Rezervacije Rezervacije { get; set; }
    }
}
