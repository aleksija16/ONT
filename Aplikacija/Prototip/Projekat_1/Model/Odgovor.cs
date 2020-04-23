using System;
using System.Collections.Generic;

namespace Projekat_1.Model
{
    public partial class Odgovor
    {
        public uint IdOdgovor { get; set; }
        public string TekstOdg { get; set; }
        public uint PitanjeId { get; set; }
        public sbyte Tacno { get; set; }

        public virtual Pitanje Pitanje { get; set; }
    }
}
