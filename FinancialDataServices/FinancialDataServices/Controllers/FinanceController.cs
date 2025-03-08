using FinancialDataServices.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancialDataServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FinanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _context.Financialdata
                .Select(f => new
                {
                    f.id,
                    f.name,
                    f.instrument, 
                    f.purchaseDate,
                    f.price,
                    f.purchaseprice,
                    f.timelineprice,
                    f.quntity,
                })
                .ToList();
            var processedData = data.Select(f => new
            {
                f.id,
                f.name,
                timelineprice = f.timelineprice?.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                     .Select(x => x.Trim()) 
                                     .Where(x => decimal.TryParse(x, out _)) 
                                     .Select(decimal.Parse) 
                                     .ToList() ?? new List<decimal>(), 
                f.instrument,
                f.purchaseDate,
                f.purchaseprice,
                f.price,
                f.quntity,
            }).ToList();
            return Ok(processedData);
        }

    }
}

