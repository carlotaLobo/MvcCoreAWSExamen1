using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcCoreAWSBlank.Models;
using MvcCoreAWSBlank.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        [HttpPost]
        public async Task<IActionResult> Index(String nombrepelicula)
        {
            return View(await this.servicedynamo.GetByNombrePelicula(nombrepelicula));
        }
        public IActionResult CreatePersonaje()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePersonaje(IFormFile imagen,
            Personaje personaje, String incluirdesc, String ojos, String genero)
        {
            
            if (imagen != null)
            {
                using (MemoryStream m = new MemoryStream())
                {
                    imagen.CopyTo(m);
                    await this.services3.UploadFile(m, imagen.FileName);
                }
                personaje.Imagen = this.services3.GetUrlFile(imagen.FileName);
            }
            if (incluirdesc != null)
            {
               Descripcion d = new Descripcion();
                d.Genero = genero;
                d.Ojos = ojos;
                personaje.Descripcion = d;
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
        public async Task<IActionResult> Delete(int id)
        {
            Personaje personaje = await this.servicedynamo.GetPersonaje(id);
            await this.servicedynamo.DeletePersonaje(id);
            String imagen = personaje.Imagen.Substring(personaje.Imagen.IndexOf(".com/") + 1, personaje.Imagen.Length - personaje.Imagen.IndexOf(".com/") - 1);
            await this.servicedynamo.DeletePersonaje(id);
            await this.services3.DeleteFile(imagen);
           
            return RedirectToAction("index");
        }
    }
}
