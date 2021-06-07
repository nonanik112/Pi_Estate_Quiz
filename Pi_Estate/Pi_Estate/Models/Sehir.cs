using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pi_Estate.Models
{
    public class Sehir
    {
        public int SehirId { get; set; }

        public string SehirName { get; set; }

        public List<Semt> Semts { get; set; }
    }
}
