﻿using Microsoft.AspNetCore.Mvc;
using Pies.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pies.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class RootController : ControllerBase
    {
        [HttpGet(Name = "GetRoot")]
        public IActionResult GetRoot()
        {
            // create links for root
            var links = new List<LinkDto>();

            links.Add(
                new LinkDto(Url.Link("GetRoot", new { }),
                "self",
                "GET"));

            links.Add(
                new LinkDto(Url.Link("GetPies", new { }),
                "pies",
                "GET"));

            links.Add(
                new LinkDto(Url.Link("CreatePies", new { }),
                "create_pies",
                "POST"));

            return Ok(links);
        }
    }
}
