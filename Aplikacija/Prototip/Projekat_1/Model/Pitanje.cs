using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Projekat_1.Model
{
    public partial class Pitanje
    {
        public uint IdPitanje { get; set; }
        [Display(Name="Pitanje")]
        [Required(ErrorMessage="*")]
        public string PitanjeTekst { get; set; }
        [Display(Name="Opcija-1")]
        [Required(ErrorMessage="*")]
        public string Opa { get; set; }
        [Display(Name="Opcija-2")]
        [Required(ErrorMessage="*")]
        public string Opb { get; set; }
        [Display(Name="Opcija-3")]
        [Required(ErrorMessage="*")]
        public string Opc { get; set; }
        [Display(Name="Tacan Odgovor")]
        [Required(ErrorMessage="*")]
        public string Tacan { get; set; }
        [Display(Name="ID kviza")]
        [Required(ErrorMessage="*")]
        public uint KvizId { get; set; }

        public virtual Kviz Kviz { get; set; }
    }
}
