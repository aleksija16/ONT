using System;
using System.Collections.Generic;

namespace Projekat_1.Model
{
    public partial class Rezervacije
    {
        public Rezervacije()
        {
            BrojOsoba=0;
        }
        public uint IdRezervacije { get; set; }
        public uint IdTuristeRez { get; set; }
        public uint IdVodicaRez { get; set; }
        public uint BrojOsoba { get; set; }
        public DateTime? DatumIzvodjenja { get; set; }
        public uint? IdTureRez { get; set; }

        public virtual Ture IdTureRezNavigation { get; set; }
    }
}
