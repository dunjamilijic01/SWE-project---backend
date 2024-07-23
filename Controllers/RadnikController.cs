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
    public class RadnikController : ControllerBase
    {

        public Context Context { get; set; }
         private readonly UserManager<AppUser> _userManager;
         public RadnikController(Context context, UserManager<AppUser> userManager )
        {
             Context = context;
             _userManager = userManager;
        }

        [HttpGet]
        [Route("Radnici/{id}")]
        [Authorize(Roles ="Menadzer")]
        public async Task<ActionResult> vratiRadnikeKafica(int id)
        {
            var radnici = await Context.Radnici.Where(p=>p.KaficId == id).ToListAsync();
            return Ok(radnici);
        }
        [HttpDelete]
        [Route("IzbrisiRadnika/{id}")]
        [Authorize(Roles ="Menadzer")]
        public async Task<ActionResult> izbrisiRadnik(int id)
        {
            var radnik = await Context.Radnici.Where(p=>p.Id == id).FirstOrDefaultAsync();
            Context.Radnici.Remove(radnik);
            await Context.SaveChangesAsync();
            return Ok("Izbrisan radnik");
        }
    }
}