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
    public class CourseController : ControllerBase
    {
        private readonly ApplicationContext _dbcontext;

        public CourseController(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        // GET: api/Course
        [HttpGet, Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _dbcontext.Courses.Where(x => x.Status == true).Select(x => new {
                    x.Id,
                    x.Name,
                    x.Point,
                    teacher = String.Concat(x.User.FirstName, " ", x.User.LastName),
                    category = x.Category.Name
                }).ToListAsync());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet, Route("[action]/{Id}")]
        public async Task<IActionResult> Get(string Id)
        {
            try
            {
                var list = await _dbcontext.Courses.Where(x => x.Status == true && x.Id == new Guid(Id)).Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Point,
                    teacher = String.Concat(x.User.FirstName, " ", x.User.LastName),
                    category = x.Category.Name,
                    list = x.CourseContent.ToList()
                }).FirstOrDefaultAsync();


                return Ok(list);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPost, Route("[action]")]
        public async Task<IActionResult> New()
        {
            try
            {
                var list = await _dbcontext.Courses.Where(x => x.Status == true && x.Id == new Guid(Id)).Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Point,
                    teacher = String.Concat(x.User.FirstName, " ", x.User.LastName),
                    category = x.Category.Name,
                    list = x.CourseContent.ToList()
                }).FirstOrDefaultAsync();


                return Ok(list);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}
