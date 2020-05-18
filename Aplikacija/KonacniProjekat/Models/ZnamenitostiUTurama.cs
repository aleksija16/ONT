using System;
using System.Collections.Generic;

namespace KonacniProjekat.Models
{
    public partial class ZnamenitostiUTurama
    {
        public uint IdZnamenitostiUTurama {get; set;}
        public uint IdZnamenitostiZut { get; set; }
        public uint IdTureZut { get; set; }

        public virtual Ture IdTureZutNavigation { get; set; }
        public virtual Znamenitosti IdZnamenitostiZutNavigation { get; set; }
    }
}
