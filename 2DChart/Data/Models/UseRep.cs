using System;
using System.Collections.Generic;

namespace _2DChart.Data.Models
{
    public partial class UseRep
    {
        public Guid UseId { get; set; }
        public Guid RepId { get; set; }
        public bool IsOwner { get; set; }

        public virtual Repository Rep { get; set; }
        public virtual User Use { get; set; }
    }
}
