using Microsoft.AspNetCore.Mvc;
using WebFamilyKey2.Data;
using WebFamilyKey2.Models;

namespace WebFamilyKey2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TenantsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TenantsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Tenants
        [HttpGet]
        public ActionResult<IEnumerable<Tenant>> GetTenants()
        {
            return _context.Tenants.ToList();
        }

        // GET: api/Tenants/5
        [HttpGet("{id}")]
        public ActionResult<Tenant> GetTenant(int id)
        {
            var tenant = _context.Tenants.Find(id);
            if (tenant == null)
            {
                return NotFound();
            }
            return tenant;
        }

        // POST: api/Tenants
        [HttpPost]
        public async Task<ActionResult<Tenant>> CreateTenant(Tenant tenant)
        {
            _context.Tenants.Add(tenant);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTenant), new { id = tenant.Id }, tenant);
        }
    }
}
