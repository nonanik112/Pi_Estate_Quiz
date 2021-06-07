using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pi_Estate.Models
{
    public class Semt
    {
        public int SemtId { get; set; }

        public string SemtName { get; set; }

        public int SehirId { get; set; }

        public virtual Sehir Sehir { get; set; }
    }
}
