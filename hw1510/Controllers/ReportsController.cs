using Microsoft.AspNetCore.Mvc;

namespace YourApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        // GET /api/reports/{year}/{month}
        [HttpGet("{year}/{month}")]
        public IActionResult GetReport([FromRoute] int year, [FromRoute] int month)
        {
            var report = new
            {
                Year = year,
                Month = month,
                TotalSales = 15342.75,
                Orders = 124,
                Message = "Monthly report generated successfully"
            };

            return Ok(report);
        }
    }
}