using System;
using System.Collections.Generic;

namespace Projekat_1.Model
{
    public partial class Rezervacije
    {
        public uint Idrezervacije { get; set; }
        public uint BrojOsoba {get; set;}
        public DateTime DatumIzvodjenja { get; set; }
 
        public uint IdturisteRez { get; set; }
        public uint IdvodicaRez { get; set; }

    
    }
}
