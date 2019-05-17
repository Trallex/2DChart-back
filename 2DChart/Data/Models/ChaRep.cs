using System;
using System.Collections.Generic;

namespace _2DChart.Data.Models
{
    public partial class ChaRep
    {
        public Guid ChaId { get; set; }
        public Guid RepId { get; set; }

        public virtual Chart Cha { get; set; }
        public virtual Repository Rep { get; set; }
    }
}
