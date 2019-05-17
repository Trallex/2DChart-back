using System;
using System.Collections.Generic;

namespace _2DChart.Data.Models
{
    public partial class Function
    {
        public Function()
        {
            ChaFun = new HashSet<ChaFun>();
            FunPar = new HashSet<FunPar>();
        }

        public Guid FunctionId { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Approximation { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<ChaFun> ChaFun { get; set; }
        public virtual ICollection<FunPar> FunPar { get; set; }
    }
}
