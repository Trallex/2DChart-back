using System;
using System.Collections.Generic;
using _2DChart.Domain.Charts;
using _2DChart.Domain.Generics;

namespace _2DChart.Domain.Function
{
    public class FunctionDto : BaseDto
    {
        public double Min { get; set; }
        public double Max { get; set; }
        public double Approximation { get; set; }
        public string Name { get; set; }
        public string FunctionString { get; set; }
        public DateTime CreationDate { get; set; }
    }
}