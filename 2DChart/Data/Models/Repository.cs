using System;
using System.Collections.Generic;

namespace _2DChart.Data.Models
{
    public partial class Repository
    {
        public Repository()
        {
            UseRep = new HashSet<UseRep>();
        }

        public Guid RepositoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<Chart> Charts { get; set; }
        public virtual ICollection<UseRep> UseRep { get; set; }
    }
}
