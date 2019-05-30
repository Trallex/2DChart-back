using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2DChart.Domain.Charts
{
    public class ChartDto
    {
        public Guid ChartId { get; set; }
        public string Logo { get; set; }
        public DateTime CreationDate { get; set; }
        public List<FunctionDto> Functions { get; set; }

    }
}
