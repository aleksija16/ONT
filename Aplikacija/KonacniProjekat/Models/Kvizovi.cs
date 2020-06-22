using System;
using System.Collections.Generic;

namespace KonacniProjekat.Models
{
    public partial class Kvizovi
    {
        public Kvizovi()
        {
            HallOfFame = new HashSet<HallOfFame>();
            Pitanja = new HashSet<Pitanja>();
        }

        public uint IdKviza { get; set; }
        public string NazivKviza { get; set; }
        public uint? IdZnamenitostiK { get; set; }
        public uint? IdTureK { get; set; }

        public virtual Ture IdTureKNavigation { get; set; }
        public virtual Znamenitosti IdZnamenitostiKNavigation { get; set; }
        public virtual ICollection<HallOfFame> HallOfFame { get; set; }
        public virtual ICollection<Pitanja> Pitanja { get; set; }
    }
}
