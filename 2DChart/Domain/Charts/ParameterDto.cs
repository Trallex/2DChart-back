using System;

namespace _2DChart.Domain.Charts
{
    public class ParameterDto
    {
        public Guid ParameterId { get; set; }
        public double Value { get; set; }
        public string Variable { get; set; }
    }
}