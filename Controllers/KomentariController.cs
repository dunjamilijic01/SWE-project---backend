using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Back.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class KomentariController : ControllerBase
    {

        private readonly UserManager<AppUser> _userManager;
        public Context Context { get; set; }

        public KomentariController(Context context, UserManager<AppUser> userManager )
        {
             Context = context;
             _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Komentari/{id}")]
        public async Task<ActionResult> Komentari(int id)
        {
            var komentari = await Context.Komentari.Include(p=>p.Kafic).Where(p=>p.Kafic.ID==id).ToListAsync();
            var user = new List<AppUser>();
            foreach(var k in komentari)
            {
                user.Add(await _userManager.FindByIdAsync(Convert.ToString(k.PosetilacId)));
            }
            if(komentari == null)
            {
               return BadRequest("Nema komentara");
            }
            int i =0;

            return Ok(
                komentari.Select(
                    p=> new{
                        id=p.ID,
                        datum=p.Datum,
                        ocena=p.Ocena,
                        text=p.TextKomentara,
                        username= user[i++].UserName,
                        curUserId=p.PosetilacId,
                        kaficId=p.Kafic.ID
                    }
                ).ToList()
            );
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("DodajKomentar/{ocena}/{text}/{posetilacid}/{kaficid}")]
        public async Task<ActionResult> DodajKomentar(int ocena, string text, int posetilacid, int kaficid)
        {
           if(ocena > 5 && ocena < 0)
           {
                return BadRequest("Ocena nije ok!");
           }
           if(text.Length > 300)
           {
                return BadRequest("Ocena nije ok!");
           }
           try
           {
                var kom = new Komentar();
                kom.Ocena = ocena;
                kom.Datum = DateTime.Now;
                kom.TextKomentara = text;
                kom.PosetilacId = posetilacid;
                
                kom.Kafic = await Context.Kafici.FindAsync(kaficid);
                var kafic=await Context.Kafici.Where(p=>p.ID==kaficid).Include(p=>p.Komentari).FirstOrDefaultAsync();
                Context.Add(kom);
                await Context.SaveChangesAsync();

                double o=0;
                foreach(var k in kafic.Komentari)
                {
                    o+=k.Ocena;
                }

                kafic.srednjaOcena=o/kafic.Komentari.Count();
               
                 await Context.SaveChangesAsync();
               
                return Ok( );
           }
           catch(Exception e)
           {
            return BadRequest(e.Message);
           }

        }
        
        [AllowAnonymous]
        [HttpDelete]
        [Route("ObrisiKomentar/{id}")]
        public async Task<ActionResult> DodajKomentar(int id, int kaficid)
        {
           try
           {
              
                var kom = await Context.Komentari.FindAsync(id);
               
                if(kom!=null)
                {
                    
                    Context.Remove(kom);
                    await Context.SaveChangesAsync();
                   
                    
                     return Ok();
                }
                else 
                {
                    return BadRequest("nema tog komentara");
                }
              
           }
           catch(Exception e)
           {
            return BadRequest(e.Message);
           }

        }
    
        [AllowAnonymous]
        [HttpPut]
        [Route("izmeniKomentar/{id}/{text}/{ocena}")]
        public async Task<ActionResult> DodajKomentar(int id,string text,int ocena)
        {
           try
           {
              
                var kom = await Context.Komentari.FindAsync(id);
                if(kom!=null)
                {
                    kom.TextKomentara=text;
                    kom.Ocena=ocena;
                    await Context.SaveChangesAsync();
                   
                     return Ok();

                
                }
                else 
                {
                    return BadRequest("nema tog komentara");
                }
              
           }
           catch(Exception e)
           {
            return BadRequest(e.Message);
           }

        }
    }
}


