using System;
using System.Collections.Generic;

namespace Projekat.Models
{
    public partial class ZnamenitostiUTurama
    {
        public uint IdZnamenitostiZut { get; set; }
        public uint IdTureZut { get; set; }

        public virtual Ture IdTureZutNavigation { get; set; }
        public virtual Znamenitosti IdZnamenitostiZutNavigation { get; set; }
    }
}
