using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeropuertoService.Models
{
    public class Puerta
    {
        public static Dictionary<int,Puerta> Puertas = new Dictionary<int, Puerta>
        {
            [1] = new Puerta() { Codigo = 1, Nombre = "Puerta 1", Ubicacion = Ubicacion.Ubicaciones.FirstOrDefault().Value}
        };
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public Ubicacion Ubicacion { get; set; }

        public static Puerta ObtenerPuerta(int codigo)
        {
            //Se obtiene la puerta por codigo
            return Puertas[codigo];
        }

        public static Puerta Add(Puerta puerta)
        {
            Puertas.Add(puerta.Codigo, puerta);
            return puerta;
        }

        public static Puerta Update(Puerta puerta)
        {
            return Puertas[puerta.Codigo] = puerta;
        }

        public static Puerta Delete(int codigo)
        {
            var puerta = Puertas[codigo];
            Puertas.Remove(codigo);
            return puerta;
        }
    }
}