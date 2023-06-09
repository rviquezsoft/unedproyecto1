using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto1.Models;

namespace Proyecto1.Views
{
    public class PlatosController : Controller
    {
        public IActionResult Index()
        {
            List<Plato> platos = new List<Plato>
            {
                new Plato
                {
                    Categoria="local",
                    Descripcion="arroz",
                    Id=1,
                    Imagen="url",
                    Nombre="plato",
                    Precio=789
                }
            };
            return View(platos);
        }
    }
}