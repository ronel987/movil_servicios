using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Movil.Models;

namespace Movil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> signInManager;
        private RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public UserController(UserManager<AppUser> usrMgrt, SignInManager<AppUser> signinMgr, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            _userManager = usrMgrt;
            signInManager = signinMgr;
            _configuration = configuration;
            this.roleManager = roleManager;
        }

        [HttpPost, Route("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterUser value)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var user = new AppUser
                    {
                        UserName = value.UserName,
                        Email = value.Email,
                        FirstName = value.FirstName,
                        LastName = value.LastName
                    };

                    var roleSearch = await roleManager.FindByNameAsync(value.Role);

                    var result = await _userManager.CreateAsync(user, value.Password);

                    if (result != null)
                    {
                        if (result.Succeeded)
                        {
                            var currentUser = await _userManager.FindByEmailAsync(value.Email);
                            await _userManager.AddToRoleAsync(currentUser, "Usuario");
                            return Ok();
                        }
                        else
                        {
                            return Ok(result.Errors);
                        }
                    }
                    else {
                        return BadRequest("El rol no existe");
                    }

                    
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, e);
                }
            }
            return Ok();
        }

        [HttpPost, Route("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginUser value)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByEmailAsync(value.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    var result = await signInManager.PasswordSignInAsync(user, value.Password, false, false);
                    var role = await _userManager.GetRolesAsync(user);

                    if (result.Succeeded)
                    {
                        // Creamos los claims (pertenencias, características) del usuario
                        var info = new
                        {
                            UserName = user.UserName,
                            idRole = role.FirstOrDefault()
                        };
                        var claims = new[]{
                            new System.Security.Claims.Claim("UserData", Newtonsoft.Json.JsonConvert.SerializeObject(info))
                        };
                        var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken
                        (
                            claims: claims,
                            expires: DateTime.UtcNow.AddDays(60),
                            notBefore: DateTime.UtcNow,
                            signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["ApiAuth:SecretKey"])),
                            Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256)
                        );

                        return Ok(new
                        {
                            Token = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().WriteToken(token),
                            FullName = String.Concat(user.FirstName, " ", user.LastName),
                            Rol = role.FirstOrDefault()
                        });
                    }
                }

                return Unauthorized();
            }

            return Ok();

        }

    }
}
