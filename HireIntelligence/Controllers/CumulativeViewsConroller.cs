using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HireIntelligence.Models;
using HireIntelligence.DB;
using Microsoft.Extensions.Logging;

namespace HireIntelligence.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class CumulativeViewsConroller:ControllerBase
    {

        private readonly ILogger<CumulativeViewsConroller> _logger;

        public CumulativeViewsConroller(ILogger<CumulativeViewsConroller> logger)
        {
            _logger = logger;
        }

        private readonly CumulativeViewsDbContext _context;

        public CumulativeViewsConroller(CumulativeViewsDbContext context)
        {
            _context = context;
        }

        // GET: api/CumulativeViews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CumulativeView>>> GetCumulativeViews()
        {
            return await _context.CumulativeViews.ToListAsync();
        }
    }
}
