using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.IO;

namespace Back.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class KaficSlikeController : ControllerBase
    {

        private readonly UserManager<AppUser> _userManager;
        public Context Context { get; set; }
        public  IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger _logger;

        public KaficSlikeController(Context context, UserManager<AppUser> userManager, IWebHostEnvironment hostingEnvironment ,ILogger<KaficSlikeController> logger)
        {
             Context = context;
             _hostingEnvironment=hostingEnvironment;
             _userManager = userManager;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Slike/{kaficid}")]
        public async Task<ActionResult> postSlike(List<IFormFile> files ,int kaficid)
        {
           try{
             
            if(files!=null && files.Count() > 0)
            {
                foreach (var item in files)
                {
                _logger.LogInformation("file uploaded : " + item.FileName);
                }

                foreach (var file in files)
                {
                    FileInfo fi=new FileInfo(file.FileName);

                    var newFileName="Image_"+DateTime.Now.TimeOfDay.Milliseconds+fi.Extension;
                    var path=Path.Combine("",_hostingEnvironment.ContentRootPath+"/Slike/"+newFileName);
                    using( var stream=new FileStream(path,FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }                    
                    var kafic=Context.Kafici.Find(kaficid);
                    KaficSlike imageupload=new KaficSlike();
                    imageupload.url=path;
                    imageupload.Kafic=kafic;
                    Context.Slike.Add(imageupload);
                    await Context.SaveChangesAsync();
                   
                }
                
                return Ok();
            }
            else
            {
                return BadRequest(files);
                
            }
           }
           catch(Exception ex)
           {
               return BadRequest(ex.Message);
           }
        }
       
    }
}


