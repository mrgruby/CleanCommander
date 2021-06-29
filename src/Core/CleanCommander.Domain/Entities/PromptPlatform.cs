using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Domain.Entities
{
    public class PromptPlatform
    {
        public Guid PlatformId { get; set; }
        public string PlatformName { get; set; }
        public virtual ICollection<CommandLine> Commands { get; set; }
    }
}
