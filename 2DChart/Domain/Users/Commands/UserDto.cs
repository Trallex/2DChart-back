using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2DChart.Domain.Generics;

namespace _2DChart.Domain.Users.Commands
{
    public class UserDto : BaseDto
    {
        public string Name { get; set; }
        public string Mail { get; set; }
    }
}
