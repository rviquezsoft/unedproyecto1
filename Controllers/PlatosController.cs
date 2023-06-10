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
        private readonly List<Plato> _platos;
        public PlatosController(List<Plato> platos)
        {
            _platos = platos;
        }
        public IActionResult Index()
        {
            return View(_platos);
        }

        [HttpPost]
        public string Crear([FromBody]Plato plato)
        {
            string result = "";

            if (plato == null || string.IsNullOrWhiteSpace(plato.Categoria) ||
                string.IsNullOrWhiteSpace(plato.Descripcion)||
                string.IsNullOrWhiteSpace(plato.Nombre)||
                plato.Precio<1|| string.IsNullOrWhiteSpace(plato.Imagen))
            {
                return "Existen datos erróneos o incompletos";
            }
            plato.Id = _platos.Count + 1;//asignar un id
            _platos.Add(plato);
            return "El plato se agregó a la lista";
        }

    }
}