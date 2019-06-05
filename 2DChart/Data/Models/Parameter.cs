using System;
using System.Collections.Generic;

namespace _2DChart.Data.Models
{
    public partial class Parameter
    {
        public Guid ParameterId { get; set; }
        public double Value { get; set; }
        public string Variable { get; set; }
        public string FunctionId { get; set; }

        public virtual Function Function { get; set; }

        public override string ToString() {
            return (Value + " * " + Variable+" ");
        }
    }
}
