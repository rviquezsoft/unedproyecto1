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
    public class ReservasController : Controller
    {
        private readonly ICRUDService<Reserva> _reservas;
        public ReservasController(ICRUDService<Reserva> reservas)
        {
            _reservas = reservas;
        }
        // GET: Reservas
        public ActionResult Index()
        {
            return View(_reservas.Get());
        }


        [HttpGet]
        public Reserva GetById([FromQuery] int id)
        {
            return _reservas.GetById("NumeroReserva", id);
        }
        [HttpPost]
        public string Crear([FromBody] Reserva reserva)
        {
            string result = "";

            if (reserva == null || string.IsNullOrWhiteSpace(reserva.NombreCliente) ||
                reserva.NumeroPersonas < 1 )
            {
                return "Existen datos erróneos o incompletos";
            }

            reserva.NumeroReserva = _reservas.CountAll() + 1;//asignar un id
            return _reservas.Add(reserva);
        }
        [HttpPut]
        public string Update([FromBody] Reserva reserva)
        {
            string result = "";

            if (reserva == null || string.IsNullOrWhiteSpace(reserva.NombreCliente) ||
                 reserva.NumeroPersonas < 1)
            {
                return "Existen datos erróneos o incompletos";
            }
            return _reservas.Update(reserva, "NumeroReserva", reserva.NumeroReserva);
        }
        [HttpDelete]
        public string Delete([FromBody] int id)
        {
            return _reservas.Delete("NumeroReserva", id);
        }


    }
}