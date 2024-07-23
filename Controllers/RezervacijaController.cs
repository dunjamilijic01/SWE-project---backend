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
    public class RezervacijaController : ControllerBase
    {

        public Context Context { get; set; }

        public RezervacijaController(Context context )
        {
            Context = context;
        }

        [HttpPost]
        [Route("DodajRezervaciju/{datum}/{vreme}/{posetilacId}/{stoId}/{kaficId}")]
        [Authorize(Roles="Admin,Posetilac")]
        public async Task<ActionResult> dodajRez(string datum,string vreme, int posetilacId,int stoId, int kaficId)
        {
            var posetilac=Context.PosetiociSaNalogom.Find(posetilacId);
            var sto=Context.Stolovi.Find(stoId);
            var rezervacija= await Context.Rezervacije.Where(p=>p.Datum.Date==(DateTime.Parse(datum)).Date && p.ZakazanoVreme==vreme && p.Sto.ID==stoId).FirstOrDefaultAsync();
            var d=DateTime.Compare(DateTime.Parse(datum).Date,DateTime.Today.Date);
            var kafic = await Context.Kafici.Where(p=>p.ID == kaficId).FirstOrDefaultAsync();
            if(d<0)
            {
                return BadRequest("Prosao je trazeni datum");
            }
            if(rezervacija==null)
            {
                if(posetilac!=null && sto!=null)
            {
                var rez=new Rezervacija();
                rez.Datum=DateTime.Parse(datum);
                rez.ZakazanoVreme=vreme;
                rez.VremeIsteka="00:00";
                rez.Posetilac=posetilac;
                rez.Sto=sto;
                rez.Kafic = kafic;

                Context.Rezervacije.Add(rez);
                await Context.SaveChangesAsync();
                return Ok(DateTime.Parse(datum));
            }
            else
            {
                return BadRequest("Greska");
            }
            }
            else{
                return BadRequest("rezervacija vec postoji !");
            }
            
        }
        [HttpGet]
        [Route("VratiRezervacije/{id}/{kafic}")]
        [Authorize(Roles="Admin,Posetilac,Menadzer")]
        public async Task<ActionResult> vratirezervacije(int id,int kafic)
        {
            var rez= await Context.Rezervacije
                        .Include(p=>p.Posetilac)
                        .Include(p=>p.Sto) 
                            .ThenInclude(q=>q.Kafic)
                        //.Include(p=>p.Sto)
                        .Where(p=>p.Posetilac.Id==id)
                        .Where(p=>p.Sto.Kafic.ID==kafic).ToListAsync();
            if(rez!=null)
            {
                return Ok(rez.Select( 
                    r=> new{
                        id=r.ID,
                        datum=r.Datum,
                        vremeIsteka=r.VremeIsteka,
                        zakazanoVreme=r.ZakazanoVreme,
                        obradjen=r.Obradjen,
                        sto=r.Sto,
                        kaficId = r.Kafic
                    }
                )
                    
                );
            }
            else
            {
                return BadRequest("greska");
            }
        }
        [HttpDelete]
        [Route("OtkaziRezervaciju/{id}")]
        [Authorize(Roles="Admin,Posetilac,Menadzer")]
        public async Task<ActionResult> otkaziRez(int id)
        {
            var rez= Context.Rezervacije.Find(id);
            if(rez!=null)
            {
                Context.Rezervacije.Remove(rez);
                await Context.SaveChangesAsync();
                return Ok();
            }
            else{
                return BadRequest("Ne postoji trazena rezervacija");
            }
        }
        [HttpPut]
        [Route("OdobriRezervaciju/{id}/{vreme}")]
        [Authorize(Roles ="Menadzer")]
        public async Task<ActionResult> odobriRezevaciju(int id,string vreme)
        {
            var rezervacija = await Context.Rezervacije.Where(p=>p.ID == id).FirstOrDefaultAsync();
            if(rezervacija!=null)
            {
                rezervacija.Obradjen = true;
                rezervacija.VremeIsteka = vreme;
                await Context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest("rezervacija ne posotji");
        }

        [HttpGet]
        [Route("vratiRez/{kaficId}")]
        [Authorize(Roles ="Radnik,Menadzer")]
        public async Task<ActionResult> vratiRez(int kaficId)
        {
            var rez = await Context.Rezervacije.Include(p=>p.Posetilac).Include(p=>p.Sto).Where(p=>p.Kafic.ID == kaficId).ToListAsync();
            if(rez!=null)
            {
                return Ok(rez.Select(r=>
                new{
                    id = r.ID,
                    datum = r.Datum,
                    zakazanoVreme = r.ZakazanoVreme,
                    obradjen = r.Obradjen,
                    posetilaId = r.Posetilac.Id,
                    posetilacUserName = r.Posetilac.UserName,
                    stoId = r.Sto,
                    vremeIsteka = r.VremeIsteka

                }).ToList());
            }
            return BadRequest("Ne postoje rez");
        }
    }
}