using System;
using System.Collections.Generic;

namespace Projekat_1.Model
{
    public partial class Kviz
    {
        public Kviz()
        {
            Pitanje = new HashSet<Pitanje>();
        }

        public uint IdKviz { get; set; }
        public string NazivKviza { get; set; }

        public virtual ICollection<Pitanje> Pitanje { get; set; }
    }
}
