using Business;
using Microsoft.AspNetCore.Mvc;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    public class AppController : Controller
    {
        private readonly IAppBs _appBs;

        public AppController(IAppBs appBs)
        {
            _appBs = appBs;
        }
        public IActionResult Index()
        {
            
            var list = _appBs.GetAll();
            return View(list);
        }
    }
}
