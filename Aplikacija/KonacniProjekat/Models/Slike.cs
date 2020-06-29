using System;
using System.Collections.Generic;

namespace KonacniProjekat.Models
{
    public partial class Slike
    {
        public int IdSlike { get; set; }
        public uint? IdZnamenitost { get; set; }
        public string Slika { get; set; }

        public virtual Znamenitosti IdZnamenitostNavigation { get; set; }
    }
}
