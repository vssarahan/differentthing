using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Abc.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [Authorize]
        public string Auth()
        {
            return "Ok";
        }

        [Authorize(Roles = "user")]
        public string User()
        {
            return "Ok";
        }

        [Authorize(Roles = "admin")]
        public string Admin()
        {
            return "Ok";
        }
    }
}
