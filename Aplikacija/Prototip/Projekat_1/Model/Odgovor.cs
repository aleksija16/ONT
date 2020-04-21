using System;
using System.Collections.Generic;

namespace Projekat_1.Model
{
    public partial class Odgovor
    {
        public uint Idodgovor { get; set; }
        public string Tekstodg { get; set; }
        public uint Pitanjeid { get; set; }
        public sbyte Tacno { get; set; }

        public virtual Pitanje Pitanje { get; set; }
    }
}
