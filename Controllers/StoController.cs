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
    public class StoController:ControllerBase
    {
         public Context Context { get; set; }
        public StoController(Context context): base()
        {
            Context = context;
        }
        [HttpGet]
        [Route("Stolovi/{kaficId}")]
        [Authorize(Roles ="Menadzer")]
        public async Task<ActionResult> vratiStoloveKafica(int kaficId)
        {
            var stolovi = await Context.Stolovi.Where(p=>p.Kafic.ID == kaficId).ToListAsync();
            if(stolovi!=null)
            {
                return Ok(stolovi);
            }
            else
            {
                return BadRequest("Ne posoje stolovi");
            }
        }
        [HttpPut]
        [Route("IzmenaBrojaMesta/{stoId}/{brojMesta}")]
        [Authorize(Roles ="Radnik,Menadzer")]
        public async Task<ActionResult> izmeniBrojMesta(int stoId, int brojMesta)
        {
            var sto = await Context.Stolovi.Where(p=>p.ID == stoId).FirstOrDefaultAsync();
            if(sto!=null)
            {
                sto.BrojLjudi = brojMesta;
                await Context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest("Sto ne postoji");
        }
        [HttpPut]
        [Route("IzmeniStatus/{stoId}/{status}")]
        [Authorize(Roles ="Radnik,Menadzer")]
        public async Task<ActionResult> izmeniStatu(int stoId, bool status)
        {
            var sto = await Context.Stolovi.Where(p=>p.ID == stoId).FirstOrDefaultAsync();
            if(sto!=null)
            {
                sto.Slobodan = status;
                await Context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest("Ne postoji sto");
        }
        [HttpPut]
        [Route("izmeniVidljivost/{stoId}/{display}")]
        [Authorize(Roles ="Menadzer")]
        public async Task<ActionResult> izmeniVidljivost(int stoId, bool display)
        {
            var sto = await Context.Stolovi.Where(p=>p.ID == stoId).FirstOrDefaultAsync();
            if(sto!=null)
            {
                sto.display = display;
                await Context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest("Ne postoji sto");
        }
        [HttpPost]
        [Route("dodajStolove/{kaficId}/{brojStolova}")]
        [Authorize(Roles ="Menadzer")]
        public async Task<ActionResult> dodajStolove(int kaficId, int brojStolova)
        {
            var kafic = await Context.Kafici.Where(p=>p.ID==kaficId).FirstOrDefaultAsync();
            if(kafic!=null)
            {
                for(int i=0; i<brojStolova;i++){
                    var sto=new Sto();
                    sto.Kafic=kafic;
                    sto.Slobodan=true;
                    sto.display = true;
                    Context.Stolovi.Add(sto);
                }
                await Context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest("Ne postoji kafic");

        }
    }
}