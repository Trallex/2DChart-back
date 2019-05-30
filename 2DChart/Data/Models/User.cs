using System;
using System.Collections.Generic;

namespace _2DChart.Data.Models
{
    public partial class User
    {
        public User()
        {
            UseRep = new HashSet<UseRep>();
        }

        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public virtual ICollection<UseRep> UseRep { get; set; }
    }
}
