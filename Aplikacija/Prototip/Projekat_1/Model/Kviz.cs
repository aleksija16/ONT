using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projekat_1.Model
{
    public partial class Kviz
    {
        public Kviz()
        {
            Pitanje = new HashSet<Pitanje>();
        }

        public uint IdKviz { get; set; }
        
        [Display(Name="Naziv Kviza")]
        [Required(ErrorMessage="*")]
        public string NazivKviza { get; set; }

        public virtual ICollection<Pitanje> Pitanje { get; set; }
    }
}
