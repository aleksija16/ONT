using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projekat_1.Model
{
    public partial class Znamenitosti
    {
         public Znamenitosti()
        {
            ZnamenitostiUTurama = new HashSet<ZnamenitostiUTurama>();
        }
        public uint IdZnamenitosti { get; set; }
        [Display(Name="Naziv Znamenitosti")]
        [Required(ErrorMessage="*")]
        public string NazivZnamenitosti { get; set; }
        public string LokacijaZnamenitosti { get; set; }
        public virtual ICollection<ZnamenitostiUTurama> ZnamenitostiUTurama { get; set; }
    }
}
