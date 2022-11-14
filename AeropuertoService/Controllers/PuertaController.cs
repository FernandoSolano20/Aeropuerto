using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AeropuertoService.Models;

namespace AeropuertoService.Controllers
{
    public class PuertaController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(Puerta.Puertas);
        }

        public IHttpActionResult Get(int codigo)
        {
            return Ok(Puerta.ObtenerPuerta(codigo));
        }

        public IHttpActionResult Post(Puerta puerta)
        {
            return Content(HttpStatusCode.OK, Puerta.Add(puerta));
        }

        public IHttpActionResult Put(Puerta puerta)
        {
            Puerta door = Puerta.Update(puerta);
            return Content(HttpStatusCode.OK, door);
        }

        public IHttpActionResult Delete(int codigo)
        {
            var msg = Puerta.Delete(codigo);
            return Content(HttpStatusCode.OK, msg);
        }
    }
}
