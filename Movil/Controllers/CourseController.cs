using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movil.Models;
using Movil.Models.Forms;

namespace Movil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ApplicationContext _dbcontext;
        private UserManager<AppUser> _userManager;

        public CourseController(ApplicationContext dbcontext, UserManager<AppUser> usrMgrt)
        {
            _dbcontext = dbcontext;
            _userManager = usrMgrt; ;
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
                    contentList = x.CourseContent.Where(y => x.Status == true).Select(y => new {
                        y.Name,
                        y.Duration
                    }).ToList()
                }).FirstOrDefaultAsync();


                return Ok(list);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet, Route("[action]")]
        public async Task<IActionResult> GetbyUser() {
            try {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                var email = identity.FindFirst("emailUser").Value;
                var query = await _userManager.FindByEmailAsync(email);

                var result = await _dbcontext.Courses.Where(x => x.User.Id == query.Id).Select(x => new {
                    code = x.Id,
                    name = x.Name,
                    description = x.Description,
                    category = x.Category.Name,
                    x.Status
                }).ToListAsync();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPost, Route("[action]/")]
        public async Task<IActionResult> Create(CourseModel value)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                var email = identity.FindFirst("emailUser").Value;
                var query = await _userManager.FindByEmailAsync(email);

                Course row = new Course()
                {
                    Id = Guid.NewGuid(),
                    Name = value.Name,
                    Description = value.Description,
                    Point = 3,
                    Status = true
                };

                var category = await _dbcontext.Categories.Where(x => x.Id == value.Id_Category).FirstOrDefaultAsync();

                row.User = query;
                row.Category = category;

                _dbcontext.Courses.Add(row);
                await _dbcontext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPut, Route("[action]/")]
        public async Task<IActionResult> UpdateCourse(CourseModel value)
        {
            try
            {
                var query = await _dbcontext.Courses.Where(x => x.Id == value.Id).FirstOrDefaultAsync();

                query.Name = value.Name;
                query.Description = value.Description;
                query.Category = await _dbcontext.Categories.Where(x => x.Id == value.Id_Category).FirstOrDefaultAsync();
                query.Status = value.Status;

                _dbcontext.Courses.Update(query);
                await _dbcontext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet, Route("[action]/{Id}")]
        public async Task<IActionResult> GetCourseContentByCourse(Guid Id) {
            try
            {
                var query = await _dbcontext.CourseContents.Where(x => x.Course.Id == Id).Select(x => new
                {
                    code = x.Id,
                    name = x.Name,
                    status = x.Status,
                    duration = x.Duration,
                    description = x.Description,
                    cost = x.Cost,
                    id_course = x.Course.Id
                }).ToListAsync();

                return Ok(query);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPost, Route("[action]/")]
        public async Task<IActionResult> CreateCourseContent(CourseContentModel value)
        {
            try
            {
                var query = await _dbcontext.Courses.Where(x => x.Id == value.Id_Course).FirstOrDefaultAsync();

                CourseContent row = new CourseContent() {
                    Id = Guid.NewGuid(),
                    Name = value.Name,
                    Description = value.Description,
                    Cost = value.Cost,
                    Duration = value.Duration,
                    Status = true,
                    Course = query
                };

                _dbcontext.CourseContents.Add(row);
                await _dbcontext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPut, Route("[action]/")]
        public async Task<IActionResult> UpdateCourseContent(CourseContentModel value)
        {
            try
            {
                var query = await _dbcontext.CourseContents.Where(x => x.Id == value.Id).FirstOrDefaultAsync();

                query.Name = value.Name;
                query.Duration = value.Duration;
                query.Status = value.Status;

                _dbcontext.CourseContents.Update(query);
                await _dbcontext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet, Route("[action]/{Id}")]
        public async Task<IActionResult> GetCourse(Guid Id)
        {
            try
            {
                var query = await _dbcontext.Courses.Where(x => x.Id == Id).Select(x => new
                {
                    code = x.Id,
                    name = x.Name,
                    description = x.Description,
                    category = x.Category.Name,
                    codeTeacher = x.User.Id,
                    fullName = String.Concat(x.User.FirstName, " ", x.User.LastName),
                    themeList = x.CourseContent.Where(y => y.Status == true).Select(y => new {
                        code = y.Id,
                        name = y.Name,
                        duration = y.Duration,
                        description = y.Description,
                        cost = y.Cost
                    }).OrderBy(y => y.name).ToList()
                }).FirstOrDefaultAsync();

                return Ok(query);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}
