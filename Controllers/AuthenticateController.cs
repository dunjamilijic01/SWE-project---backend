using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Models;
using Microsoft.AspNetCore.Authorization;

namespace Back.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AuthenticateController : ControllerBase
    {
      
        public Context _context { get; set; }
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager,IConfiguration configuration, SignInManager<AppUser> signInManager, Context context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _signInManager = signInManager;
            _context = context;
            SeedData.Seed(_userManager,_roleManager,_context);
        }
        //Register posetilac sa nalogom (radiiiiiiiiiiiiiiiiiiiii)
        //Kada se registruje da li da se vrati token???
        [HttpPost]
        [Route("register-user/{username}/{ime}/{prezime}/{email}/{password}/{brojTelefona}")]
        public async Task<ActionResult> Register(string username, string ime, string prezime, string email, string password, string brojTelefona)
        {
           try
            {
                AppUser user = await _userManager.FindByEmailAsync(email);
                if(user == null)
                {
                    user = new Posetilac();
                    user.UserName = username;
                    user.Ime = ime;
                    user.Prezime = prezime;
                    user.Email = email;
                    user.PhoneNumber = brojTelefona;
                    user.SecurityStamp = Guid.NewGuid().ToString();
                    var result = await _userManager.CreateAsync(user, password);

                    if(!result.Succeeded)
                        return BadRequest("Error");
                    else
                        _userManager.AddToRoleAsync(user,"Posetilac").Wait();
                   var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim("id", Convert.ToString(user.Id)),
                    new Claim("userName", user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("ime", Convert.ToString(user.Ime)),
                    new Claim("prezime", Convert.ToString(user.Prezime)),
                    new Claim("telefon", Convert.ToString(user.PhoneNumber)),
                    new Claim("email", Convert.ToString(user.Email))
                };
                foreach(var useRole in userRoles)
                {
                    authClaims.Add(new Claim("role", useRole));
                }
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
                var data = userRoles[0];
                await _signInManager.SignInAsync(user,false);
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token), 
                    expiration = token.ValidTo,

                });
                
                    
                }
                else
                {
                    return BadRequest("User postoji!");
                }
                

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // Sve jedno da li je kafic id ili naziv lako je promenljivo
        [HttpPost]
        [Route("register-radnik/{ime}/{prezime}/{kaficId}/{pozicija}/{brojTelefona}")]
        [Authorize(Roles ="Menadzer")]
        public async Task<ActionResult> RegisterRadnik(string ime, string prezime,int kaficId, string pozicija, string brojTelefona)
        {
            //Email: kaficNaziv.radnikBrojTogRadnika@gmail.com
            var kafic =await _context.Kafici.Include(k=>k.Radnici).Where(k=> k.ID == kaficId).FirstOrDefaultAsync();
            if(kafic!=null)
            {
                
                var brojRadnika = kafic.Radnici.Count();
                string password = "Radnik123!";
                string UserName = kafic.Naziv + pozicija + brojRadnika;
                string email = kafic.Naziv + '.' + ime + brojRadnika + "@gmail.com";
                Radnik user = new Radnik();
                user.UserName = UserName;
                user.Email = email;
                user.Ime = ime;
                user.Prezime = prezime;
                user.Kafic = kafic;
                user.Vlasnik = false;
                user.Pozicija = pozicija;
                user.PhoneNumber = brojTelefona;
                user.SecurityStamp = Guid.NewGuid().ToString();
                var result = await _userManager.CreateAsync(user,password);
                if(!result.Succeeded)
                        return BadRequest("Error");
                    else
                        _userManager.AddToRoleAsync(user,"Radnik").Wait();
                    return Ok("ok");
            }

            return Ok();
        }
        //Radnik dodavanje 
        [HttpPost]
        [Route("register-menadzer/{ime}/{prezime}/{kaficId}/{email}/{brojTelefona}")]
        public async Task<ActionResult> Register(string ime, string prezime,int kaficId, string email, string brojTelefona)
        {
            //Email: kaficNaziv.radnikBrojTogRadnika@gmail.com
            //Ili jos bolje sa username-om da se loguje a ne mejlom i onda bi to bilo ovako kaficNaziv.Pozicija+Id
            var kafic =await _context.Kafici.Include(k=>k.Radnici).Where(k=> k.ID == kaficId).FirstOrDefaultAsync();
            if(kafic!=null)
            {
                var brojRadnika = kafic.Radnici.Count();
                string password = "Menadzer123!";
                string UserName = kafic.Naziv + "Menadzer";
           
                Radnik user = new Radnik();
                user.UserName = UserName;
                user.Email = email;
                user.Ime = ime;
                user.Prezime = prezime;
                user.Kafic = kafic;
                user.Vlasnik = true;
                user.Pozicija = "Menadzer";
                user.PhoneNumber = brojTelefona;
                user.SecurityStamp = Guid.NewGuid().ToString();
                var result = await _userManager.CreateAsync(user,password);
                if(!result.Succeeded)
                        return BadRequest("Error");
                    else
                        _userManager.AddToRoleAsync(user,"Menadzer").Wait();
                    return Ok("ok");
                
                
            }

            return Ok();
        }




        [HttpPost]
        [Route("login/{emailPassword}")]
        public async Task<IActionResult> Login(string emailPassword)
        {
            var bytes = Convert.FromBase64String(emailPassword);
            string[] niz = Encoding.UTF8.GetString(bytes).Split(":");
            var result = await _userManager.FindByEmailAsync(niz[0]);
            if(result!= null && await _userManager.CheckPasswordAsync(result, niz[1]))
            {
                await _signInManager.PasswordSignInAsync(result,niz[1],true,true);
                var userRoles = await _userManager.GetRolesAsync(result);
                var authClaims =new List<Claim>();
                if(userRoles[0]!= "Admin"){
                    authClaims = new List<Claim>
                    {
                    
                        new Claim("id", Convert.ToString(result.Id)),
                        new Claim("userName", result.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim("ime", Convert.ToString(result.Ime)),
                        new Claim("prezime", Convert.ToString(result.Prezime)),
                        new Claim("telefon", Convert.ToString(result.PhoneNumber)),
                        new Claim("email", Convert.ToString(result.Email))

                        
                        
                    };
                }
                    else
                    {
                         authClaims = new List<Claim>
                    {
                      
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };
                    }
                    
                foreach(var useRole in userRoles)
                {
                    authClaims.Add(new Claim("role", useRole));
                }
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
                
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token),
                });
            }
            return BadRequest("jbg");
        }

        [HttpPut]
        [Route("edit/{id}/{ime}/{prezime}/{brojTelefona}")]
        public async Task<IActionResult> Edit(int id, string ime, string prezime, string brojTelefona)
        {
            try
            {
             
                var user = await _userManager.FindByIdAsync(Convert.ToString(id));
                if(user!= null)
                {
                    user.Ime = ime;
                    user.Prezime = prezime;
                    user.PhoneNumber = brojTelefona;
                    await _userManager.UpdateAsync(user);
                    
                
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var authClaims = new List<Claim>
                    {
                        new Claim("id", Convert.ToString(user.Id)),
                        new Claim("userName", user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim("ime", Convert.ToString(user.Ime)),
                        new Claim("prezime", Convert.ToString(user.Prezime)),
                        new Claim("telefon", Convert.ToString(user.PhoneNumber)),
                        new Claim("email", Convert.ToString(user.Email))
                    };
                    foreach(var useRole in userRoles)
                    {
                        authClaims.Add(new Claim("role", useRole));
                    }
                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token),
                });
                }
                return Ok("");


            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("Logout")]
        public async Task<ActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return Ok("User logged out");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("getuser")]
        [Authorize(Roles="Admin,Menadzer,Radnik,Posetilac")]
        public async Task<ActionResult> GetUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var id = Int32.Parse(identity.FindFirst("id").Value);

            var user = await _userManager.FindByIdAsync(Convert.ToString(id));
            var role = await _userManager.GetRolesAsync(user);
            if(role==null)
            {
                return BadRequest("Korisnik ne protoji");
            }
            if(role[0]=="Posetilac")
            {
                
                Posetilac newUser = new Posetilac();
               newUser = (Posetilac)user;
            
                if(newUser == null)
                {
                    return BadRequest("Nevalidan korinsik");
                }
                //Ovde mozes klasika da dodajes sve sto ti treba, ja mislim da je ovo ok
                return Ok(
                    new{
                        role = role,
                        id = newUser.Id,
                        ime = newUser.Ime,
                        prezime = newUser.Prezime,
                        userName = newUser.UserName,
                        telefon = newUser.PhoneNumber,
                        email = newUser.Email,
                        datumRodjena = newUser.DatumRodjenja
                    }
                );
            }   

            if(role[0] =="Menadzer")
            {
                var newUser =  _context.Radnici.Where(p=>p.Id == id).FirstOrDefault();
                var kafic =await _context.Kafici.Include(p=>p.Dogadjaji)
                                                .Include(p=>p.Radnici)
                                                .Include(p=>p.Stolovi)
                                                    .ThenInclude(p=>p.Rezervacija)
                                                .Where(p=>p.ID == newUser.KaficId).FirstOrDefaultAsync();
                var rezervacija = await _context.Stolovi.Include(p=>p.Rezervacija).Where(p=>p.Kafic.ID == kafic.ID).Where(p=>p.Rezervacija!=null).ToListAsync();
                if(newUser == null)
                {
                    return BadRequest("Nevalidan menadzer");
                }
                return Ok(
                    new{
                        role,
                        vlasnik = newUser.Vlasnik,
                        kaficInfo=kafic,
                        dogadjaj = kafic.Dogadjaji,
                        radnici = kafic.Radnici,
                        stolovi = kafic.Stolovi,
                        rezervacije = kafic.Stolovi.Select((s)=>
                        new{
                            s.Rezervacija
                        }).ToList()
                        
                    }
                );
            }
             if(role[0] =="Radnik")
            {
                var newUser = _context.Radnici.Where(p=>p.Id == id).FirstOrDefault();
                var kafic = await _context.Kafici.Where(p=>p.ID==newUser.KaficId).FirstOrDefaultAsync();
                if(newUser == null)
                {
                    return BadRequest("Nevalidan Radnik");
                }
                return Ok(
                    new{
                        role,
                        kaficInfo = kafic
                    }
                );
            }
            if(role[0] =="Admin")
            {
                var newUser = _context.Users.Where(p=>p.Id == id).FirstOrDefault();
                if(newUser == null)
                {
                    return BadRequest("Nevalidan Radnik");
                }
                return Ok(
                    new{
                        ime = newUser.Ime,
                        prezime = newUser.Prezime,
                        telefon = newUser.PhoneNumber
                       
                    } 
                );
            }

            return BadRequest("nevalidna uskuga");

    



        }


      


        




    }
}
