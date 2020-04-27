using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Projekat_1.Model
{
    public partial class HallOfFame
    {
        public uint RedniBroj { get; set; }
        [Display(Name="Ime")]
        [Required(ErrorMessage="*")]
        public string ImeTuriste { get; set; }
         [Display(Name="Prezime")]
        [Required(ErrorMessage="*")]
        public string PrezimeTuriste { get; set; }
         [Display(Name="Broj Poena")]
        [Required(ErrorMessage="*")]
        public uint BrojPoena { get; set; }
    }
}
