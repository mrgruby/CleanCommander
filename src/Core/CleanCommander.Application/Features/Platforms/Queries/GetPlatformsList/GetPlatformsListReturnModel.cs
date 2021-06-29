using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Platforms.Queries.GetPlatformsList
{
    public class GetPlatformsListReturnModel
    {
        public Guid PlatformId { get; set; }
        public string PlatformName { get; set; }
        public virtual ICollection<GetPlatformsListCommandDto> CommandLines { get; set; }
    }
}
