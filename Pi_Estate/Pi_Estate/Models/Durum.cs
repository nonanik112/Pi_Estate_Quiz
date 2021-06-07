using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pi_Estate.Models
{
    public class Durum
    {
        public int DurumId { get; set; }

        public string DurumName { get; set; }

        public List<Tip> Tips { get; set; }
    }
}
