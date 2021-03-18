using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenTimesheets.Shared.Entities;

namespace OpenTimesheets.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkShiftController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        public WorkShiftController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(WorkShift ws)
        {
            context.Add(ws);
            await context.SaveChangesAsync();
            return ws.Id;
        }


        /*
        public IActionResult Index()
        {
            return View();
        }
        */
    }
}
