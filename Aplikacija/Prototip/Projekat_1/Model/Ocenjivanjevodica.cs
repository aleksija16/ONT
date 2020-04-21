using System;
using System.Collections.Generic;

namespace Projekat_1.Model
{
    public partial class Ocenjivanjevodica
    {
        public uint Idocenjivanjevodica { get; set; }
        public uint? IdvodicaOcenjivanje { get; set; }
        public uint? Ocena { get; set; }
    }
}
