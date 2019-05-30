using System;
using System.Collections.Generic;

namespace _2DChart.Domain.Charts
{
    public class FunctionDto
    {
        public Guid FunctionId { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Approximation { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<ParameterDto> Parameters { get; set; }
    }
}