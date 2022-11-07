using Microsoft.AspNetCore.Mvc;
using BookHistory.Models;
using BookHistory.Repository;

namespace BookHistory.Controllers
{
    public class AuditsController : AuditsApiControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public AuditsController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public override async Task<ActionResult<IEnumerable<Audit>>> GetAuditLogs([FromQuery] AuditParameters auditParameters)
        {
            try
            {
                if (auditParameters.endYear < auditParameters.startYear)
                {
                    return BadRequest("EndYear cannot be earlier than start year");
                }

                var books = await _repository.Audit.GetAuditsAsync(auditParameters);

                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex.Message}");
            }
        }
    }
}
