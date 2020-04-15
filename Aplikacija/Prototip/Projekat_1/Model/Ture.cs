using System;
using System.Collections.Generic;

namespace Projekat_1.Model
{
    public partial class Ture
    {
        public uint Idture { get; set; }
        public string NazivTure { get; set; }
        public uint? TrajanjeTure { get; set; }

        public virtual Rezervacije Rezervacije { get; set; }
    }
}
