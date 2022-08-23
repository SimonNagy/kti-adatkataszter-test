using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ktiAdatkataszt.Models
{
    public partial class Testframe
    {
        public int Id { get; set; }
        
        public DateTime Dátum { get; set; }

        public string? Név { get; set; }

        public string? Kategória { get; set; }
        
        public byte Melléklet { get; set; }
    }
}
