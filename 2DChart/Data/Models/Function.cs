using System;
using System.Collections.Generic;

namespace _2DChart.Data.Models
{
    public partial class Function
    {
        public Guid FunctionId { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public int Approximation { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string FunctionString { get; set; }
        public Guid? ChartId { get; set; }

        public virtual Chart Chart { get; set; }
    }
}
