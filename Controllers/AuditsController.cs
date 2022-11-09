using Microsoft.AspNetCore.Mvc;
using BookHistory.Models;
using BookHistory.Repository;
using BookHistory.Models.DTOs;

namespace BookHistory.Controllers
{
    public class AuditsController : AuditsApiControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ILogger _logger;

        public AuditsController(IRepositoryWrapper repository, ILogger<BooksController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public override async Task<ActionResult<IEnumerable<Audit>>> GetAuditLogs([FromQuery] AuditParameters auditParameters)
        {
            try
            {
                if (auditParameters.EndYear < auditParameters.StartYear)
                {
                    return BadRequest("EndYear cannot be earlier than start year");
                }

                var audits = await _repository.Audit.GetAuditsAsync(auditParameters);

                return Ok(audits);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return StatusCode(500, $"Internal server error {ex.Message}");
            }
        }

        public override async Task<ActionResult<IEnumerable<AuditGroupedByBookId>>> GetActionCountPerBook()
        {
            try
            {
                var actionCountPerBookId = await _repository.Audit.GetActionCount();

                return Ok(actionCountPerBookId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return StatusCode(500, $"Internal server error {ex.Message}");
            }
        }
    }
}
