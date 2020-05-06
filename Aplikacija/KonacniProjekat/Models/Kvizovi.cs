﻿using System;
using System.Collections.Generic;

namespace KonacniProjekat.Models
{
    public partial class Kvizovi
    {
        public uint IdKviza { get; set; }
        public string NazivKviza { get; set; }
        public uint? IdZnamenitostiK { get; set; }

        public virtual Znamenitosti IdZnamenitostiKNavigation { get; set; }
        public virtual HallOfFame HallOfFame { get; set; }
        public virtual Pitanja Pitanja { get; set; }
    }
}