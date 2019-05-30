using System;
using System.Collections.Generic;

namespace _2DChart.Data.Models
{
    public partial class Repository
    {
        public Repository()
        {
            ChaRep = new HashSet<ChaRep>();
            UseRep = new HashSet<UseRep>();
        }

        public Guid RepositoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<ChaRep> ChaRep { get; set; }
        public virtual ICollection<UseRep> UseRep { get; set; }
    }
}
