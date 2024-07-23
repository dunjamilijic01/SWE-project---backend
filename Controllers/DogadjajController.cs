using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Models;
using Microsoft.AspNetCore.Authorization;

namespace Back.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DogadjajController : ControllerBase
    {

        public Context Context { get; set; }
        public DogadjajController(Context context )
        {
            Context = context;
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("Dogadjaji")]
        public async Task<ActionResult> Dogadjaji()
        {
            var dogadjaji = await Context.Dogadjaji.Include(p=>p.Kafic).ToListAsync();

            return Ok(
                dogadjaji.Select(
                    p=> new
                    {
                        vrstaDogadjaja = p.VrstaDogadjaja,
                        naziv = p.Naziv,
                        opis = p.Opis,
                        idKafica = p.Kafic.ID,
                        nazivKafica = p.Kafic.Naziv,
                        datum=p.Datum.ToString("yyyy-MM-dd"),
                        vreme=p.Vreme
                    }
                ).ToList()
            );
        }
        [HttpGet]
       [Route("Dogadjaj/{kaficId}")]
       [AllowAnonymous]
       public async Task<ActionResult> vratiKafic(int kaficId)
       {
           var dog = await Context.Dogadjaji.Where(p=>p.Kafic.ID ==kaficId).ToListAsync();
           if(dog == null)
           {
               return BadRequest("Kafic nema dogadjaje!");
           }

           return Ok(
               dog
           );
       }


       [HttpDelete]
       [Route("IzbrisiDoagadjaj/{id}")]
       [Authorize(Roles ="Menadzer")]
       public async Task<ActionResult> izbrisiKafic(int id)
       {
            var dogadjaj = await Context.Dogadjaji.Where(p=>p.ID == id).FirstOrDefaultAsync();
            Context.Dogadjaji.Remove(dogadjaj);
            await Context.SaveChangesAsync();
            return Ok();

       }
       [HttpPost]
       [Route("DodajDogadjaj/{kaficId}/{naziv}/{vrstaDogadjaja}/{opis}/{datum}/{vreme}")]
       [Authorize(Roles ="Menadzer")]
       public async Task<ActionResult> dodajDogadjaj(int kaficId, string naziv, string vrstaDogadjaja, string opis ,DateTime datum, string vreme)
       {
            var dogadjaj = new Dogadjaj();
            dogadjaj.Naziv = naziv;
            dogadjaj.Opis = opis;
            dogadjaj.VrstaDogadjaja = vrstaDogadjaja;
            dogadjaj.Datum =datum;
            dogadjaj.Vreme = vreme;
            dogadjaj.Kafic = await Context.Kafici.Where(p=>p.ID == kaficId).FirstOrDefaultAsync();
            Context.Dogadjaji.Add(dogadjaj);
            await Context.SaveChangesAsync();
            return Ok();
       }

    }
}