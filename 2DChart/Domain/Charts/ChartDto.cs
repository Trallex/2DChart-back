using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2DChart.Domain.Function;
using _2DChart.Domain.Generics;

namespace _2DChart.Domain.Charts
{
    public class ChartDto : BaseDto
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<FunctionDto> Functions { get; set; }

    }
}
