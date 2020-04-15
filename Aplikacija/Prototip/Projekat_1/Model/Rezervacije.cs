using System;
using System.Collections.Generic;

namespace Projekat_1.Model
{
    public partial class Rezervacije
    {
        public uint Idrezervacije { get; set; }
        public uint IdturisteRez { get; set; }
        public uint IdvodicaRez { get; set; }
        public uint IdtureRez { get; set; }
        public DateTime? DatumIzvodjenja { get; set; }

        public virtual Ture IdtureRezNavigation { get; set; }
        public virtual Turisti IdturisteRezNavigation { get; set; }
        public virtual Vodici IdvodicaRezNavigation { get; set; }
    }
}
