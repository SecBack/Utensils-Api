﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Utensils_Api.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        [HttpGet]
        public ActionResult<int> Get()
        {
            return 5;
        }
    }
}
