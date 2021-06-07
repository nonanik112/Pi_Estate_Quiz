using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pi_Estate.Models
{
    public class Resim
    {
        public int ResimId { get; set; }
        public string ResimName { get; set; }
        public int IlanId { get; set; }
        public virtual Ilan Ilan { get; set; }

    }
}
