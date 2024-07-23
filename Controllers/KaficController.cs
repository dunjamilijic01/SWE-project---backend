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
    public class KaficController : ControllerBase
    {

        public Context Context { get; set; }
        public KaficController(Context context )
        {
            Context = context;
        }
        [HttpGet]
        [Route("Kafici")]
        [AllowAnonymous]
        public async Task<ActionResult> ListaKafica()
        {
            var kafici = await Context.Kafici
                                .Include(p=>p.Dogadjaji)
                                .Include(p=>p.Komentari)
                                .ToListAsync();
            return Ok(kafici);
        }
    

       [HttpGet]
       [Route("Kafic/{naziv}")]
       [AllowAnonymous]
       public async Task<ActionResult> vratiKafic(string naziv)
       {
           var kafic = await Context.Kafici.Include(p=>p.Dogadjaji).Include(p=>p.Stolovi).Where(p=>p.Naziv == naziv).FirstOrDefaultAsync();
           if(kafic == null)
           {
               return BadRequest("Kafic ne postoji!");
           }

           return Ok(
               new{
                id=kafic.ID,
                naziv=kafic.Naziv,
                lokacija=kafic.Lokacija,
                radnoVreme=kafic.RadnoVreme,
                vrseRezervacije=kafic.VrseRezervacije,
                brojMesta=kafic.BrojMesta,
                srednjaOcena=kafic.srednjaOcena,
                brojTelefona=kafic.BrojTelefona,
                instagram=kafic.Instagram,
                facebook=kafic.Facebook,
                //slike=kafic.Slike,
                dogadjaji= kafic.Dogadjaji,
                stolovi=kafic.Stolovi
               }
           );
       }
       [AllowAnonymous]
       [HttpGet]
       [Route("kaficiSlobodnaMesta/{brMesta}")]
        public async Task<ActionResult> vratiKafic(int brMesta)
        {
            var kafici = await Context.Kafici.Where(k=>k.BrojMesta>=brMesta).ToListAsync();
            if(kafici == null)
            {
                //Ovde ti vracam Bad request ako nema ni jedan kafic koji ima izavrani broj mesta
                return BadRequest();
            }
            else
                return Ok(kafici);

        }
        
        [HttpGet]
        [Route("KaficLog/{id}")]
        [Authorize(Roles ="Menadzer,Radnik")]
        public async Task<ActionResult> vratiKafic1(int id)
        {
            var kafic = await Context.Kafici.Include(p=>p.Dogadjaji)
                                            .Include(p=>p.Radnici)
                                            .Where(p=>p.ID == id).FirstOrDefaultAsync();
            if(kafic == null)
            {
                return BadRequest("Kafic ne postoji!");
            }

            return Ok(
                new
                {
                    kaficInfo = kafic,
                    dogadjaji = kafic.Dogadjaji,
                    radnici = kafic.Radnici
                }
            );
        }
        [HttpPut]
        [Route("IzmeniPodatke/{id}/{naziv}/{radnoVreme}/{lokacija}/{brojTelefona}")]
        [Authorize(Roles ="Menadzer")]
        public async Task<ActionResult> izmeniKafic(int id,string naziv, string radnoVreme, string lokacija, string brojTelefona)
        {
            try
            {
                var kafic = await Context.Kafici.Where(p=>p.ID == id).FirstOrDefaultAsync();
                if(kafic!= null)
                {
                    kafic.Naziv = naziv;
                    kafic.BrojTelefona = brojTelefona;
                    kafic.RadnoVreme = radnoVreme;
                    kafic.Lokacija = lokacija;

                    await Context.SaveChangesAsync();
                    return Ok();
                }
                else
                return BadRequest("Kafic ne postoji");

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        [Route("StatusRezervisanja/{id}/{rez}")]
        [Authorize(Roles ="Menadzer")]
        public async Task<ActionResult> Rezervacije(int id,bool rez)
        {
            try
            {   
                var kafic = await Context.Kafici.Where(p=>p.ID == id).FirstOrDefaultAsync();
                if(kafic!=null)
                {
                    kafic.VrseRezervacije = rez;
                    await Context.SaveChangesAsync();
                    return Ok();
                }
                return BadRequest("Kafic ne postoji");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("DodajKafic/{naziv}/{lokacija}/{vreme}/{vrsiRez}/{brojStolova}")]
        [Authorize(Roles="Admin")]
        public async Task<ActionResult> DodajKafic(string naziv,string lokacija,string vreme,bool vrsiRez,int brojStolova){
            var kafic=new Kafic();
            kafic.Naziv=naziv;
            kafic.Lokacija=lokacija;
            kafic.RadnoVreme=vreme;
            kafic.VrseRezervacije=vrsiRez;
            kafic.BrojStolova=brojStolova;
            
            for(int i=0;i<brojStolova;i++)
            {
                var sto=new Sto();
                sto.Kafic=kafic;
                sto.Slobodan=true;
                Context.Stolovi.Add(sto);
            }
            Context.Kafici.Add(kafic);
            await Context.SaveChangesAsync();
            return Ok(kafic.ID);
        }
        [HttpDelete]
        [Route("ObrisiKafic/{id}")]
        [Authorize(Roles="Admin")]
        public async Task<ActionResult> ObrisiKafic(int id)
        {
            var kafic=Context.Kafici.Find(id);
            if(kafic!=null)
            {
                Context.Kafici.Remove(kafic);
                await Context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest("Nema tog kafica");
            }
        }
       
    }
}