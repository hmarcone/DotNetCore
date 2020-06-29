using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProAgil.WebApi.Model;

namespace ProAgil.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("Evento")]
        public IEnumerable<Evento> GetEvento()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Evento
            {
                EventoId = index,
                Tema = $"Angular e .Net Core {index}",
                Local = $"Belo Horizonte {index}",
                Lote = $"{index}º Lote",
                QtdPessoas = 249 + index,
                DataEvento = DateTime.Now.AddDays(index).ToString("dd/MM/yyyy")
                // Date = DateTime.Now.AddDays(index),
                // TemperatureC = rng.Next(-20, 55),
                // Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("Evento/{id}")]
        public IEnumerable<Evento> GetEvento(int id)
        {
            var rng = new Random();
            var listEvento =  Enumerable.Range(1, 5).Select(index => new Evento
            {
                EventoId = index,
                Tema = $"Angular e .Net Core {index}",
                Local = $"Belo Horizonte {index}",
                Lote = $"{index}º Lote",
                QtdPessoas = 249 + index,
                DataEvento = DateTime.Now.AddDays(index).ToString("dd/MM/yyyy")
            })
            .ToArray();

            return listEvento.Where(x => x.EventoId == id);
        }

    }
}
