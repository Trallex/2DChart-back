using System;
using System.Collections.Generic;

namespace _2DChart.Data.Models
{
    public partial class FunPar
    {
        public Guid FunId { get; set; }
        public Guid ParId { get; set; }

        public virtual Function Fun { get; set; }
        public virtual Parameter Par { get; set; }
    }
}
