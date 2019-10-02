using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movil.Models;

namespace Movil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ApplicationContext _dbcontext;

        public CategoryController(ApplicationContext dbcontext) {
            _dbcontext = dbcontext;
        }
        
        // GET: api/Category
        [HttpGet, Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _dbcontext.Categories.Where(x => x.Status == true).OrderBy(x => x.Name).ToListAsync());
            }
            catch (Exception e) {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Category
        [HttpPost, Route("[action]")]
        public async Task<IActionResult> Create(Category value)
        {
            if (ModelState.IsValid) {
                try
                {
                    value.Id = Guid.NewGuid();
                    _dbcontext.Categories.Add(value);
                    await _dbcontext.SaveChangesAsync();
                    return Ok();
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, e);
                }
            }

            return BadRequest();
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
