using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatesterAPI.Controllers
{
    public class MatchController : ApiController
    {
        public async Task<IActionResult> GetPotentialMatches()
        {

            return Ok();
        }
    }
}
