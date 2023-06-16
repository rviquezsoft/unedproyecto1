using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1.Models;
using Proyecto1.Services;

namespace Proyecto1.Views
{
    public class VentasController : Controller
    {
        private readonly ICRUDService<Venta> _ventas;
        public VentasController(ICRUDService<Venta> ventas)
        {
            _ventas = ventas;
        }
        public ActionResult Index()
        {
            return View(_ventas.Get());
        }


        [HttpGet]
        public Venta GetById([FromQuery] int id)
        {
            return _ventas.GetById("NumeroOrden", id);
        }
        [HttpPost]
        public string Crear([FromBody] Venta venta)
        {
            string result = "";

            if (venta == null || string.IsNullOrWhiteSpace(venta.NombrePlatoVendido) ||
                venta.CantidadVendida < 1 ||
                venta.NumeroOrden < 1)
            {
                return "Existen datos erróneos o incompletos";
            }

            venta.NumeroOrden = _ventas.CountAll() + 1;//asignar un id
            return _ventas.Add(venta);
        }
        [HttpPut]
        public string Update([FromBody] Venta venta)
        {
            string result = "";

            if (venta == null || string.IsNullOrWhiteSpace(venta.NombrePlatoVendido) ||
               venta.CantidadVendida < 1 ||
               venta.NumeroOrden < 1)
            {
                return "Existen datos erróneos o incompletos";
            }
            return _ventas.Update(venta, "NumeroOrden", venta.NumeroOrden);
        }
        [HttpDelete]
        public string Delete([FromBody] int id)
        {
            return _ventas.Delete("NumeroOrden", id);
        }
    }
}