using System;
using System.Collections.Generic;

namespace _2DChart.Data.Models
{
    public partial class Parameter
    {
        public Parameter()
        {
            FunPar = new HashSet<FunPar>();
        }

        public Guid ParameterId { get; set; }
        public double Value { get; set; }
        public string Variable { get; set; }

        public virtual ICollection<FunPar> FunPar { get; set; }
    }
}
