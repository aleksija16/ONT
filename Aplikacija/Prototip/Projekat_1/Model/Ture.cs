using System;
using System.Collections.Generic;

namespace Projekat_1.Model
{
    public partial class Ture
    {
        public Ture()
        {
            Rezervacije = new HashSet<Rezervacije>();
            ZnamenitostiUTurama = new HashSet<ZnamenitostiUTurama>();
        }

        public uint IdTure { get; set; }
        public string NazivTure { get; set; }
        public uint? TrajanjeTure { get; set; }
        public DateTime? DatumOdrzavanja { get; set; }
        public TimeSpan? VremeOdrzavanja { get; set; }
        public uint? IdVodicaTura { get; set; }

        public virtual Vodici IdVodicaTuraNavigation { get; set; }
        public virtual ICollection<Rezervacije> Rezervacije { get; set; }
         public virtual ICollection<ZnamenitostiUTurama> ZnamenitostiUTurama { get; set; }
    }
}
