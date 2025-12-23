using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptiMark.DAL;

namespace OptiMark.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly OptiMarkDbContext _dbContext;

        public CompanyController(OptiMarkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("companies")]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _dbContext.Companies
                .Select(c => new
                {
                    c.Id,
                    c.CompanyName
                })
                .ToListAsync();

            return Ok(companies);
        }
    }
}