using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AeropuertoService.Models;

namespace AeropuertoService.Controllers
{
    public class UbicacionController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(Ubicacion.Ubicaciones);
        }

        public IHttpActionResult Get(int codigo)
        {
            return Ok(Ubicacion.ObtenerUbicacion(codigo));
        }

        public IHttpActionResult Post(Ubicacion ubicacion)
        {
            return Content(HttpStatusCode.OK, Ubicacion.Add(ubicacion));
        }

        public IHttpActionResult Put(Ubicacion ubicacion)
        {
            Ubicacion u = Ubicacion.Update(ubicacion);
            return Content(HttpStatusCode.OK, u);
        }

        public IHttpActionResult Delete(int codigo)
        {
            var msg = Ubicacion.Delete(codigo);
            return Content(HttpStatusCode.OK, msg);
        }
    }
}
