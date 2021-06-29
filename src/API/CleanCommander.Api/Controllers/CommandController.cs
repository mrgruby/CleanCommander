using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCommander.Api.Controllers
{
    [Route("api/platform/{platformId}/commands")]
    [ApiController]
    public class CommandController : ControllerBase
    {
    }
}
