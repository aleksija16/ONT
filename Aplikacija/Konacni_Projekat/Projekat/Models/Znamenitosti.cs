﻿using System;
using System.Collections.Generic;

namespace Projekat.Models
{
    public partial class Znamenitosti
    {
        public Znamenitosti()
        {
            Kvizovi = new HashSet<Kvizovi>();
        }

        public uint IdZnamenitosti { get; set; }
        public string NazivZnamenitosti { get; set; }
        public string Lokacija { get; set; }
        public string Opis { get; set; }
        public string RadnoVreme { get; set; }
        public string BrojTelefona { get; set; }
        public string CenaUlaznice { get; set; }

        public virtual Pitanja Pitanja { get; set; }
        public virtual ZnamenitostiUTurama ZnamenitostiUTurama { get; set; }
        public virtual ICollection<Kvizovi> Kvizovi { get; set; }
    }
}
