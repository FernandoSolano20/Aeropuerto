using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeropuertoService.Models
{
    public class Ubicacion
    {
        public static Dictionary<int,Ubicacion> Ubicaciones = new Dictionary<int,Ubicacion>
        {
            [1] = new Ubicacion() { Codigo = 1, nivelEdificio = 1}
        };
        public int nivelEdificio { get; set; }
        public int Codigo { get; set; }

        public static Ubicacion ObtenerUbicacion(int codigo)
        {
            return Ubicaciones[codigo];
        }

        public static Ubicacion Add(Ubicacion ubicacion)
        {
            Ubicaciones.Add(ubicacion.Codigo, ubicacion);
            return ubicacion;
        }

        public static Ubicacion Update(Ubicacion ubicacion)
        {
            return Ubicaciones[ubicacion.Codigo] = ubicacion;
        }

        public static string Delete(int codigo)
        {
            Ubicaciones.Remove(codigo);
            return "Eliminado";
        }
    }
}