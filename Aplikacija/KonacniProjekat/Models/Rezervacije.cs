﻿using System;
using System.Collections.Generic;

namespace KonacniProjekat.Models
{
    public partial class Rezervacije
    {
        public uint IdRezervacije { get; set; }
        public uint? IdTuristeR { get; set; }
        public uint? IdTureR { get; set; }
        public uint? IdVodicaR { get; set; }
        public DateTime Datum { get; set; }
        public uint? BrojOsoba { get; set; }

        public virtual Ture IdTureRNavigation { get; set; }
        public virtual Turisti IdTuristeRNavigation { get; set; }
        public virtual Vodici IdVodicaRNavigation { get; set; }
    }
}
