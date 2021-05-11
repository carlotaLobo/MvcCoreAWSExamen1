using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcCoreAWSBlank.Models;
using MvcCoreAWSBlank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreAWSBlank.Controllers
{
    public class PersonajesController : Controller
    {
        PersonajesServiceDynamodb servicedynamo;
        PersonajesServiceS3 services3;

        public PersonajesController(PersonajesServiceDynamodb servicedynamo, PersonajesServiceS3 services3)
        {
            this.servicedynamo = servicedynamo;
            this.services3 = services3;
        }
        public async Task<IActionResult> Index()
        {
            return View(await this.servicedynamo.GetPersonajes());
        }
        public async IActionResult CreatePersonaje()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePersonaje(IFormFile imagen, Personaje personaje )
        {
            await this.servicedynamo.CreatePersonaje()
        }
    }
}
