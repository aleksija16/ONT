using System;
using System.Collections.Generic;

namespace KonacniProjekat.Models
{
    public partial class Ture
    {
        public Ture()
        {
            Anketa = new HashSet<Anketa>();
            Kvizovi = new HashSet<Kvizovi>();
            OcenjivanjeVodica = new HashSet<OcenjivanjeVodica>();
            Rezervacije = new HashSet<Rezervacije>();
            ZnamenitostiUTurama = new HashSet<ZnamenitostiUTurama>();
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
        public virtual ICollection<Anketa> Anketa { get; set; }
        public virtual ICollection<Kvizovi> Kvizovi { get; set; }
        public virtual ICollection<OcenjivanjeVodica> OcenjivanjeVodica { get; set; }
        public virtual ICollection<Rezervacije> Rezervacije { get; set; }
        public virtual ICollection<ZnamenitostiUTurama> ZnamenitostiUTurama { get; set; }
    }
}
