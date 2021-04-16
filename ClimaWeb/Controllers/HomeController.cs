using ClimaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClimaWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Paises> paises = new List<Paises>();
            Paises sel = new Paises();
            List<Ciudades> ciudades = new List<Ciudades>();
            Ciudades ciudad = new Ciudades();
            ciudad.IdPais = 0;
            ciudad.IdCiudad = 0;
            ciudad.Descripcion = "Seleccioná una ciudad";
            ciudades.Add(ciudad);
            sel.IdPais = 0;
            sel.Descripcion = "Seleccioná un país";
            paises = GetPaises();
            paises.Add(sel);
            ViewBag.Paises = paises.OrderBy(pais => pais.IdPais).ToList();
            ViewBag.Ciudades = ciudades.OrderBy(ciu => ciu.IdCiudad).ToList();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<Paises> GetPaises()
        {
            using (var db = new ClimaContext())
            {
                List<Paises> paises = db.Paises.ToList();

                //Logueo 
                _logger.LogInformation("Obtengo los paises. " + " - " + DateTime.Now.ToString());

                return paises;
            }
        }

        [HttpGet]
        public string GetCiudades(int id)
        {
            List<Ciudades> ciudades = new List<Ciudades>();
            using (var db = new ClimaContext())
            {
                ciudades = db.Ciudades.Where(ciu => ciu.IdPais == id).OrderBy(c => c.Descripcion).ToList();
            }

            //Logueo
            _logger.LogInformation("Obtengo las ciudades para el pais " + id.ToString() + " - " + DateTime.Now.ToString());

            return JsonConvert.SerializeObject(ciudades);
        }

        public async Task<string> GetWeather()
        {
            try
            {
                string apiResponse = string.Empty;
                using (var httpClient = new HttpClient())
                {
                    string url = "https://localhost:44356/WeatherForecast";
                    using (var response = await httpClient.GetAsync(url))
                    {
                        apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }

                //Logueo
                _logger.LogInformation("Obtengo los valores del tiempo. - " + DateTime.Now.ToString());

                return apiResponse;
            }
            catch(Exception ex)
            {
                //Logueo el error
                _logger.LogError("Error al obtener los vlores del tiempo. - " + ex.Message + " - " + DateTime.Now.ToString());
                return "Error al obtener los datos del tiempo";
            }
            
        }
    }
}
