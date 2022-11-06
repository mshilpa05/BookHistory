using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookHistory.Models;

namespace BookHistory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditsController : ControllerBase
    {
        private readonly BookContext _context;

        public AuditsController(BookContext context)
        {
            _context = context;
        }

        // GET: api/Audits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Audit>>> GetAuditLogs()
        {
            return await _context.AuditLogs.ToListAsync();
        }

        // GET: api/Audits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Audit>> GetAudit(int id)
        {
            var audit = await _context.AuditLogs.FindAsync(id);

            if (audit == null)
            {
                return NotFound();
            }

            return audit;
        }
    }
}
