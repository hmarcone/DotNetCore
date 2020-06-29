using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProAgil.WebApi.Data;
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
        private readonly ProAgilContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ProAgilContext context)
        {
            _context = context;
            _logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> Get()
        {
            try
            {
                var results = await _context.Eventos.ToListAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }
            //ToDo: retirar depois
            // var rng = new Random();
            // return Enumerable.Range(1, 5).Select(index => new Evento
            // {
            //     EventoId = index,
            //     Tema = $"Angular e .Net Core {index}",
            //     Local = $"Belo Horizonte {index}",
            //     Lote = $"{index}º Lote",
            //     QtdPessoas = 249 + index,
            //     DataEvento = DateTime.Now.AddDays(index).ToString("dd/MM/yyyy")
            //     // Date = DateTime.Now.AddDays(index),
            //     // TemperatureC = rng.Next(-20, 55),
            //     // Summary = Summaries[rng.Next(Summaries.Length)]
            // })
            // .ToArray();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _context.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }

            //var rng = new Random();
            //var listEvento = Enumerable.Range(1, 5).Select(index => new Evento
            //{
            //    EventoId = index,
            //    Tema = $"Angular e .Net Core {index}",
            //    Local = $"Belo Horizonte {index}",
            //    Lote = $"{index}º Lote",
            //    QtdPessoas = 249 + index,
            //    DataEvento = DateTime.Now.AddDays(index).ToString("dd/MM/yyyy")
            //})
            //.ToArray();

            //return listEvento.Where(x => x.EventoId == id);
        }

    }
}
