using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Domain.Entities
{
    public class Platform
    {
        public int PlatformId { get; set; }
        public string PlatformName { get; set; }
        public virtual ICollection<Command> Commands { get; set; }
    }
}
