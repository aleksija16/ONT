using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KonacniProjekat.Models
{
    public partial class HallOfFame
    {
        public uint IdHallOfFame { get; set; }
        public uint? IdTuristeHof { get; set; }
        public uint? IdKvizaHof { get; set; }
        public int Poeni { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DatumRadjenja { get; set; }

        public virtual Kvizovi IdKvizaHofNavigation { get; set; }
        public virtual Turisti IdTuristeHofNavigation { get; set; }
    }
}
