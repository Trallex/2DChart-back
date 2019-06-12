using System;
using System.Collections.Generic;

namespace _2DChart.Data.Models
{
    public partial class Function
    {
        public Function()
        {
            Parameters = new HashSet<Parameter>();
        }

        public Guid FunctionId { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Approximation { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid? ChartId { get; set; }

        public virtual Chart Chart { get; set; }
        public virtual ICollection<Parameter> Parameters { get; set; }
    }
}
