using System;
using System.Collections.Generic;

namespace Projekat_1.Model
{
    public partial class Pitanje
    {
        public Pitanje()
        {
            Odgovor = new HashSet<Odgovor>();
        }

        public uint Idpitanje { get; set; }
        public string Tekstpitanja { get; set; }
        public uint Kvizid { get; set; }

        public virtual Kviz Kviz { get; set; }
        public virtual ICollection<Odgovor> Odgovor { get; set; }
    }
}
