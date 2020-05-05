using System;
using System.Collections.Generic;

namespace KonacniProjekat.Models
{
    public partial class Pitanja
    {
        public uint IdPitanja { get; set; }
        public string TekstPitanja { get; set; }
        public string OdgovorA { get; set; }
        public string OdgovorB { get; set; }
        public string OdgovorC { get; set; }
        public string TacanOdgovor { get; set; }
        public uint? IdZnamenitosti { get; set; }
        public uint? IdKviza { get; set; }

        public virtual Kvizovi IdKvizaNavigation { get; set; }
        public virtual Znamenitosti IdZnamenitostiNavigation { get; set; }
    }
}
