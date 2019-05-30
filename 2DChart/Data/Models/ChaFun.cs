using System;
using System.Collections.Generic;

namespace _2DChart.Data.Models
{
    public partial class ChaFun
    {
        public Guid ChaId { get; set; }
        public Guid FunId { get; set; }

        public virtual Chart Cha { get; set; }
        public virtual Function Fun { get; set; }
    }
}
