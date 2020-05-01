using System;
using System.Collections.Generic;

namespace Projekat.Models
{
    public partial class OcenjivanjeVodica
    {
        public uint IdOcenjivanja { get; set; }
        public uint? IdVodicaO { get; set; }
        public uint? IdTuristeO { get; set; }
        public uint? IdTureO { get; set; }
        public int Ocena { get; set; }

        public virtual Ture IdTureONavigation { get; set; }
        public virtual Turisti IdTuristeONavigation { get; set; }
        public virtual Vodici IdVodicaONavigation { get; set; }
    }
}
