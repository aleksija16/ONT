using System;
using System.Collections.Generic;

namespace Projekat.Models
{
    public partial class Ture
    {
        public Ture()
        {
            Anketa = new HashSet<Anketa>();
        }

        public uint IdTure { get; set; }
        public string NazivTure { get; set; }
        public string DanOdrzavanja { get; set; }
        public string VremeOdrzavanja { get; set; }
        public string MestoPolaska { get; set; }
        public uint? Kapacitet { get; set; }
        public uint? IdVodica { get; set; }
        public string Opis { get; set; }
        public string TipTure { get; set; }

        public virtual Vodici IdVodicaNavigation { get; set; }
        public virtual OcenjivanjeVodica OcenjivanjeVodica { get; set; }
        public virtual Rezervacije Rezervacije { get; set; }
        public virtual ZnamenitostiUTurama ZnamenitostiUTurama { get; set; }
        public virtual ICollection<Anketa> Anketa { get; set; }
    }
}
