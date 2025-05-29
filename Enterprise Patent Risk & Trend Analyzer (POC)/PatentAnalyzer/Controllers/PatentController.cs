using Microsoft.AspNetCore.Mvc;
using PatentAnalyzer.Models;
using PatentAnalyzer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatentAnalyzer.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // This makes the route "/api/Patents"
    public class PatentsController : ControllerBase
    {
        private readonly IPatentDataService _patentDataService;

        public PatentsController(IPatentDataService patentDataService)
        {
            _patentDataService = patentDataService;
        }

        // POST: api/Patents/ingest?count=10
        [HttpPost("ingest")]
        public async Task<IActionResult> IngestPatents([FromQuery] int count = 5)
        {
            await _patentDataService.IngestNewPatentsAsync(count);
            return Ok($"Ingestion of {count} patents initiated.");
        }

        // GET: api/Patents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patent>>> GetPatents()
        {
            var patents = await _patentDataService.GetAllPatentsAsync();
            return Ok(patents);
        }

        // GET: api/Patents/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Patent>> GetPatent(string id)
        {
            var patent = await _patentDataService.GetPatentByIdAsync(id);
            if (patent == null)
            {
                return NotFound();
            }
            return Ok(patent);
        }

        // GET: api/Patents/risks
        [HttpGet("risks")]
        public async Task<ActionResult<IEnumerable<Risk>>> GetRisks()
        {
            var risks = await _patentDataService.GetRisksAsync();
            return Ok(risks);
        }

        // GET: api/Patents/trends
        [HttpGet("trends")]
        public async Task<ActionResult<IEnumerable<Trend>>> GetTrends()
        {
            var trends = await _patentDataService.GetTrendsAsync();
            return Ok(trends);
        }
    }
}