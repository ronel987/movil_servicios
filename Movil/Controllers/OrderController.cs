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
    public class OrderController : ControllerBase
    {
        private readonly ApplicationContext _dbcontext;
        private UserManager<AppUser> _userManager;

        public OrderController(ApplicationContext dbcontext, UserManager<AppUser> usrMgrt)
        {
            _dbcontext = dbcontext;
            _userManager = usrMgrt;
        }

        [HttpPost, Route("[action]")]
        public async Task<IActionResult> CreateOrder(OrderModel value)
        {
            try {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                var email = identity.FindFirst("emailUser").Value;
                var user = await _userManager.FindByEmailAsync(email);
                var teacher = await _userManager.FindByIdAsync(value.IdTeacher);

                var EndDate = value.StartDate.AddHours(value.time);

                var order = new Order() {
                    Id = Guid.NewGuid(),
                    StartDate = value.StartDate,
                    time = value.time,
                    EndDate = EndDate,
                    CreateAt = DateTime.Now,
                    status = "1",
                    Student = user,
                    Teacher = teacher
                };

                _dbcontext.Orders.Add(order);
                await _dbcontext.SaveChangesAsync();

                foreach (var item in value.IdCourseContent)
                {
                    var courseContent = await _dbcontext.CourseContents.Where(x => x.Id == Guid.Parse(item)).FirstOrDefaultAsync();

                    var xx = new CourseContentOrder()
                    {
                        Id = Guid.NewGuid(),
                        CourseContent = courseContent,
                        Order = order
                    };

                    _dbcontext.CourseContentOrders.Add(xx);
                    await _dbcontext.SaveChangesAsync();
                }

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }

        }


        
    }
}
