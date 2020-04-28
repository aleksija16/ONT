using System;
using System.Collections.Generic;

namespace Projekat_1.Model
{
    public partial class ZnamenitostiUTurama
    {
        public uint TuraId { get; set; }
        public uint ZnamenitostId { get; set; }

        public virtual Ture Tura { get; set; }
        public virtual Znamenitosti Znamenitost { get; set; }
    }
}
