using Business;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.ComplexTypes;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AppController : ControllerBase
    {
        private readonly IAppBs _appBs;

        public AppController(IAppBs appBs)
        {
            _appBs = appBs;
        }
        [HttpGet("getapp")]
        public IActionResult GetApps(string name)
        {
            var urlApps =_appBs.GetByUrl(name);
            if (urlApps!=null)
            {
                if (urlApps.Active==false)
                {
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.Credentials = new NetworkCredential("yazilimmusty@gmail.com", "256581rake");
                    client.EnableSsl = true;
                    MailMessage msj = new MailMessage();
                    msj.From = new MailAddress("yazilimmusty@gmail.com", "Apps Control"); 
                    msj.To.Add("celikmustafayasin@gmail.com");
                    msj.Subject = "Apps Kapalıdır.";
                    msj.Body = "Apps Şuan Kapalıdır. Bu bilgilendirme Mesajıdır.";
                    client.Send(msj);
                    return BadRequest("E-mail has been sent.");
                }
                else
                {
                    return Ok(urlApps);
                }
               
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost("newapp")]
        public IActionResult NewApp(NewAppVm vm)
        {
            if (vm.Name!=""&&vm.Url!=""&&vm.Active!="")
            {
                App app = new App();
                app.Name = vm.Name;
                app.Url = vm.Url;
                if (vm.Active == "active")
                {
                    app.Active = true;
                }
                else
                {
                    app.Active = false;
                }
                _appBs.Insert(app);
                return Ok();
            }
            else
            {
                return BadRequest("Error");
            }
        }
        [HttpPut("updateapp")]
        public IActionResult Update(NewAppVm vm)
        {
            if (vm.Name != "" && vm.Url != "" && vm.Active != "")
            {
                App app = _appBs.GetById(Convert.ToInt32(vm.Id));
                app.Name = vm.Name;
                app.Url = vm.Url;
                if (vm.Active == "active")
                {
                    app.Active = true;
                }
                else
                {
                    app.Active = false;
                }
                _appBs.Update(app);
                return Ok();
            }
            else
            {
                return BadRequest("Error");
            }
        }
        [HttpPost("deleteapp/{id}")]
        public IActionResult Delete(int id)
        {
            _appBs.Delete(id); ;
            return Ok("Ürün Silindi");
        }

    }
}
