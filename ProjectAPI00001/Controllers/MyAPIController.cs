using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI00001.Models;

namespace ProjectAPI00001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public MyAPIController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Table1>>> GetData()
        {
            if (_dbContext.Table1 == null)
            {
                return NotFound();
            }

            return await _dbContext.Table1.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Table1>> GetDataAsync(int id)
        {
            if (_dbContext.Table1 == null)
            {
                return NotFound();
            }

            var data = await _dbContext.Table1.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return data;
        }

        [HttpPost]
        public async Task<ActionResult<Table1>> PostData(Table1 data)
        {
            var request = new Table1(
                data.SensorId,
                data.SensorData,
                data.SensorName
            );

            _dbContext.Table1.Add(data);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetData), new { id = request.Id }, request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutData(int id, Table1 data)
        {
            if (id != data.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(data).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!DataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData(int id)
        {
            if (_dbContext.Table1 == null)
            {
                return NotFound();
            }

            var data = await _dbContext.Table1.FindAsync(id);
            if( data == null)
            {
                return NotFound();
            }

            _dbContext.Table1.Remove(data);
            await _dbContext.SaveChangesAsync();

            return Ok(id);
        }

        private bool DataExists (int id)
        {
            return (_dbContext.Table1?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
