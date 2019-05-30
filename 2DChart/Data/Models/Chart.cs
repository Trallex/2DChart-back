using System;
using System.Collections.Generic;

namespace _2DChart.Data.Models
{
    public partial class Chart
    {
        public Chart()
        {
            ChaFun = new HashSet<ChaFun>();
            ChaRep = new HashSet<ChaRep>();
        }

        public Guid ChartId { get; set; }
        public string Logo { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<ChaFun> ChaFun { get; set; }
        public virtual ICollection<ChaRep> ChaRep { get; set; }
    }
}
