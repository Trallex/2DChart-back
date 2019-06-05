using System;
using System.Collections.Generic;
using _2DChart.Domain.Charts;
using _2DChart.Domain.Generics;

namespace _2DChart.Domain.Repository
{
    public class RepositoryDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public List<ChartDto> Charts { get; set; }
    }
}