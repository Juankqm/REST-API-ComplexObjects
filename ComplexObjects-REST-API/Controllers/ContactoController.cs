using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComplexObjects_REST_API.Models;
using ComplexObjects_REST_API.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComplexObjects_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {

        [HttpGet ("{Id}")]
        public IActionResult Get(int Id)
        {
            ContactoViewModel oContacto = new ContactoViewModel();
            using (AgendaContext DB = new AgendaContext())
            {
                oContacto = (from d in DB.Contacto
                             where d.IdContacto == Id
                             select new ContactoViewModel
                             {
                                 ID_Contacto = d.IdContacto,
                                 Nombre = d.Nombre,
                                 COrreoElectronico = d.CorreoElectronico,
                                 Numeros = (from c in DB.NumeroTelefono
                                            where c.IdContacto == d.IdContacto
                                            select new NumeroTelefonoViewModel
                                            {
                                                ID_NumeroTelefono = c.IdNumeroTelefono,
                                                Numero = c.Numero
                                            }).ToList()
                             }).FirstOrDefault();
            }
            return Ok(oContacto);
        }

    }
}