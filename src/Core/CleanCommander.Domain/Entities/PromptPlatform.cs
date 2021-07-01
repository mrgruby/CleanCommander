using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Domain.Entities
{
    public class PromptPlatform
    {
        public Guid PromptPlatformId { get; set; }
        public string PromptPlatformName { get; set; }
        public virtual ICollection<CommandLine> CommandLineList { get; set; }
    }
}
