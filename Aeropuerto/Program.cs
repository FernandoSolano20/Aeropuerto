using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AeropuertoService.Models;
using Newtonsoft.Json;

namespace Aeropuerto
{
    class Program
    {
        static void Main(string[] args)
        {
            var opc = 0;
            do
            {
                mostrarMenu();
                opc = Convert.ToInt32(Console.ReadLine());
                procesarOpc(opc);
            } while (opc != 7);


        }

        static void mostrarMenu()
        {
            Console.WriteLine("Digite lo que deseea");
            Console.WriteLine("1- Paises");
            Console.WriteLine("2- Aeropuerto");
            Console.WriteLine("3- Gates");
            Console.WriteLine("4- Vuelos");
            Console.WriteLine("5- Lineas aereas");
            Console.WriteLine("6- Ubicaciones");
            Console.WriteLine("7- Salir");
        }

        static void procesarOpc(int opc)
        {
            int crudOpc = 0;
            switch (opc)
            {
                case 1:
                    crudOpc = crudMethod();
                    break;

                case 2:
                    crudOpc = crudMethod();
                    break;

                case 3:
                    crudOpc = crudMethod();
                    crudGates(crudOpc);
                    break;

                case 4:
                    crudOpc = crudMethod();
                    break;

                case 5:
                    crudOpc = crudMethod();
                    break;

                case 6:
                    crudOpc = crudMethod();
                    break;

                case 7:
                    crudOpc = crudMethod();
                    break;

                default:
                    Console.WriteLine("Adios");
                    break;
            }
        }

        static int crudMethod()
        {
            Console.WriteLine("Digite lo que deseea");
            Console.WriteLine("1- Crear");
            Console.WriteLine("2- Listar por id");
            Console.WriteLine("3- Listar");
            Console.WriteLine("4- Elimianar");
            Console.WriteLine("5- Modificar");
            return Convert.ToInt32(Console.ReadLine());
        }

        static void crudGates(int opc)
        {
            switch (opc)
            {
                case 1:
                    createGate();
                    break;
                case 2:
                    listByIdGate();
                    break;
                case 3:
                    listAllGates();
                    break;
                case 4:
                    deleteGate();
                    break;
                case 5:
                    updateGate();
                    break;
            }
        }

        static async void createGate()
        {
            var url = "https://localhost:44394/api/Puerta";
            var client = new HttpClient { BaseAddress = new Uri(url) };
            var puerta = new Puerta();
            Console.WriteLine("Codigo");
            puerta.Codigo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Nombre");
            puerta.Nombre = Console.ReadLine();

            Console.WriteLine("Codigo Ubicacion");
            puerta.Ubicacion = new Ubicacion();
            puerta.Ubicacion.Codigo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Codigo nivel edificion");
            puerta.Ubicacion.nivelEdificio = Convert.ToInt32(Console.ReadLine());

            var json = JsonConvert.SerializeObject(puerta);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(url, content);
            var resultAsync = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Puerta>(resultAsync);
            Console.WriteLine(puerta.Codigo +" "+ puerta.Nombre);
        }

        static async void listByIdGate()
        {
            Console.WriteLine("Codigo");
            int codigo = Convert.ToInt32(Console.ReadLine());
            var url = "https://localhost:44394/api/Puerta?codigo="+ codigo + "";
            var client = new HttpClient { BaseAddress = new Uri(url) };
            var responseMessage = await client.GetAsync(url, HttpCompletionOption.ResponseContentRead);
            var resultAsync = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Puerta>(resultAsync);
            Console.WriteLine(result);
        }

        static async void listAllGates()
        {
            var url = "https://localhost:44394/api/Puerta";
            var client = new HttpClient { BaseAddress = new Uri(url) };
            var responseMessage = await client.GetAsync(url, HttpCompletionOption.ResponseContentRead);
            var resultAsync = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IDictionary<int, Puerta>>(resultAsync);
            Console.WriteLine(result);
        }

        private static async void deleteGate()
        {
            Console.WriteLine("Codigo");
            int codigo = Convert.ToInt32(Console.ReadLine());
            var url = "https://localhost:44394/api/Puerta?codigo=" + codigo + "";
            var client = new HttpClient { BaseAddress = new Uri(url) };
            var responseMessage = await client.DeleteAsync(url);
            var resultAsync = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Puerta>(resultAsync);

            Console.WriteLine(result.Codigo);
        }

        static async void updateGate()
        {
            var url = "https://localhost:44394/api/Puerta";
            var client = new HttpClient { BaseAddress = new Uri(url) };
            var puerta = new Puerta();
            Console.WriteLine("Codigo");
            puerta.Codigo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Nombre");
            puerta.Nombre = Console.ReadLine();
            puerta.Ubicacion = new Ubicacion();
            Console.WriteLine("Codigo Ubicacion");
            puerta.Ubicacion.Codigo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Codigo nivel edificion");
            puerta.Ubicacion.nivelEdificio = Convert.ToInt32(Console.ReadLine());

            var json = JsonConvert.SerializeObject(puerta);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(url, content);
            var resultAsync = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Puerta>(resultAsync);

            Console.WriteLine(result.Codigo);
        }
    }
}
