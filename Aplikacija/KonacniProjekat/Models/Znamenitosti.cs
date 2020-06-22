using System;
using System.Collections.Generic;

namespace KonacniProjekat.Models
{
    public partial class Znamenitosti
    {
        public Znamenitosti()
        {
            Kvizovi = new HashSet<Kvizovi>();
            Slike = new HashSet<Slike>();
        }

        public uint IdZnamenitosti { get; set; }
        public string NazivZnamenitosti { get; set; }
        public string Lokacija { get; set; }
        public string Opis { get; set; }
        public string RadnoVreme { get; set; }
        public string BrojTelefona { get; set; }
        public string CenaUlaznice { get; set; }
        public string Slika { get; set; }
		public string Tip { get; set; }

        public virtual Pitanja Pitanja { get; set; }
        public virtual ZnamenitostiUTurama ZnamenitostiUTurama { get; set; }
        public virtual ICollection<Kvizovi> Kvizovi { get; set; }
        public virtual ICollection<Slike> Slike { get; set; }
    }
}
