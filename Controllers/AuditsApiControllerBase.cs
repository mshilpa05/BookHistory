using BookHistory.Models;
using BookHistory.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookHistory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class AuditsApiControllerBase : ControllerBase
    {
        [HttpGet]
        public abstract Task<ActionResult<IEnumerable<Audit>>> GetAuditLogs(AuditParameters auditParameters);

        [HttpGet("/actionCount")]
        public abstract Task<ActionResult<IEnumerable<AuditGroupedByBookId>>> GetActionCountPerBook();
    }
}
