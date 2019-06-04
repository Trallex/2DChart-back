using System;
using System.Collections.Generic;

namespace _2DChart.Data.Models
{
    public partial class Chart
    {
        public Chart()
        {
            Functions = new HashSet<Function>();
        }

        public Guid ChartId { get; set; }
        public string Logo { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid RepositoryId { get; set; }

        public virtual Repository Repository { get; set; }
        public virtual ICollection<Function> Functions { get; set; }
    }
}
