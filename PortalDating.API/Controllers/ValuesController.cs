using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalDating.API.Data;
using PortalDating.API.Models;

namespace PortalDating.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _dbContext;

        public ValuesController(DataContext dbContextContext)
        {
            _dbContext = dbContextContext;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbContext.Values.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            return Ok(await _dbContext.Values.FirstOrDefaultAsync(v => v.Id.Equals(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Value value)
        {
            await _dbContext.Values.AddAsync(value);
            await _dbContext.SaveChangesAsync();
            return Ok(value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Value value)
        {
            var valueResult = await _dbContext.Values.FirstOrDefaultAsync(v => v.Id.Equals(id));

            if (valueResult == null)
                return NoContent();

            valueResult.Name = value.Name;

            _dbContext.Values.Update(valueResult);
            await _dbContext.SaveChangesAsync();

            return Ok(valueResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await _dbContext.Values.FirstOrDefaultAsync(v => v.Id.Equals(id));

            if (value == null)
                return NoContent();

            _dbContext.Values.Remove(value);
            await _dbContext.SaveChangesAsync();

            return Ok(value);
        }
    }
}
