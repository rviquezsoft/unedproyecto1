using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto1.Models;
using Proyecto1.Services;

namespace Proyecto1.Views
{
    public class PlatosController : Controller
    {
        private readonly ICRUDService<Plato> _platos;
        public PlatosController(ICRUDService<Plato> platos)
        {
            _platos = platos;
        }
        public IActionResult Index()
        {
            return View(_platos.Get());
        }
        [HttpGet]
        public Plato GetById([FromQuery] int id)
        {
            return _platos.GetById("Id",id);
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
            
            plato.Id = _platos.CountAll() + 1;//asignar un id
            return _platos.Add(plato);
        }
        [HttpPut]
        public string Update([FromBody] Plato plato)
        {
            string result = "";

            if (plato == null || string.IsNullOrWhiteSpace(plato.Categoria) ||
                string.IsNullOrWhiteSpace(plato.Descripcion) ||
                string.IsNullOrWhiteSpace(plato.Nombre) ||
                plato.Precio < 1 || string.IsNullOrWhiteSpace(plato.Imagen))
            {
                return "Existen datos erróneos o incompletos";
            }
            return _platos.Update(plato,"Id",plato.Id);
        }
        [HttpDelete]
        public string Delete([FromBody] int id)
        {
            return _platos.Delete("Id", id);
        }

    }
}