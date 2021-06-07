using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pi_Estate.Models
{
    public class Mahalle
    {
        public int MahalleId { get; set; }

        public string MahalleName { get; set; }

        public int SemtId { get; set; }

        public int SehirId { get; set; }

        public virtual Semt Semt { get; set; }

        public List<Mahalle> Mahalles { get; set; }
    }
}
