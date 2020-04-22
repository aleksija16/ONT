using System;
using System.Collections.Generic;

namespace Projekat_1.Model
{
    public partial class OcenjivanjeVodica
    {
        public uint IdOcenjivanjeVodica { get; set; }
        public uint? IdVodicaOcenjivanje { get; set; }
        public uint? Ocena { get; set; }
    }
}
