using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcCoreAWSBlank.Repositories;

namespace MvcCoreAWSBlank.Controllers
{
    public class HomeController : Controller
    {
        Repository repo;
        public HomeController(Repository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            return View(this.repo.GetCoches());
        }
    }
}
