using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Models;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Back.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PosetilacController : ControllerBase
    {

        public Context Context { get; set; }
         private readonly UserManager<AppUser> _userManager;

        public PosetilacController(Context context ,UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            Context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Posetilac")]
        public async Task<ActionResult> Posetioci()
        {
            var posetoici = await _userManager.GetUsersInRoleAsync("Posetilac");
            if(posetoici == null)
            {
               return BadRequest("Nema komentara");
            }

            return Ok(
               posetoici
                   
            );
        }
        [HttpGet]
        [Route("InfoOposetiocu/{id}")]
        [Authorize(Roles ="Menadzer")]
        public async Task<ActionResult> vratiPosetioca(int id)
        {
            var pos = await _userManager.FindByIdAsync(Convert.ToString(id));
            if(pos != null)
            {
                return Ok(new
                {
                    email = pos.Email,
                    userName = pos.UserName

                });
            }
            return BadRequest("Ne postoji user");

        }

       
        
    }
}