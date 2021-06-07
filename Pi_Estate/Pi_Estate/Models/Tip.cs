﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pi_Estate.Models
{
    public class Tip
    {
        public int TipId { get; set; }

        public string TipName { get; set; }

        public int DurumId { get; set; }

        public virtual Durum Durum { get; set; }

       

    }
}
