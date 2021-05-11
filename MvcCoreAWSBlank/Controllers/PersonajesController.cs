using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcCoreAWSBlank.Models;
using MvcCoreAWSBlank.Services;
using System;
using System.Collections.Generic;
using System.IO;
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
        public IActionResult CreatePersonaje()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePersonaje(IFormFile imagen, Personaje personaje)
        {
            
            if (imagen != null)
            {
                using (MemoryStream m = new MemoryStream())
                {
                    imagen.CopyTo(m);
                    await this.services3.UploadFile(m, imagen.FileName);
                    //Stream stream = await this.services3.GetFile(imagen.FileName);
                }
                personaje.Imagen = imagen.FileName;
            }
            await this.servicedynamo.CreatePersonaje(personaje);

            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Details(int id)
        {
            //Buscamos al personaje:
            Personaje personaje = await this.servicedynamo.GetPersonaje(id);
           
            return View(personaje);
        }
        public async Task<IActionResult> FileAws(String file)
        {
            return File(await this.services3.GetFile(file), "image/png");
        }
    }
}
