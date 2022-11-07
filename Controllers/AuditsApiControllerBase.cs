using BookHistory.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookHistory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class AuditsApiControllerBase : ControllerBase
    {
        // GET: api/Audits
        [HttpGet]
        public abstract Task<ActionResult<IEnumerable<Audit>>> GetAuditLogs(AuditParameters auditParameters);
    }
}
