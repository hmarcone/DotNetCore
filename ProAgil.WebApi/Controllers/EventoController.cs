using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain.Entities;
using ProAgil.Infrastructure.DbModels;
using ProAgil.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProAgil.WebApi.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class EventoController : ControllerBase
	{
		private readonly IProAgilRepository _repo;
		private readonly IMapper _mapper;

		public EventoController(IProAgilRepository repo, IMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				var eventos = await _repo.GetAllEventoAsync(true);

				var results = _mapper.Map<EventoModel[]>(eventos);

				return Ok(results);
			}
			catch (System.Exception ex)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
			}
		}

		[HttpGet("{EventoId}")]
		public async Task<IActionResult> Get(int EventoId)
		{
			try
			{
				var evento = await _repo.GetEventoAsyncById(EventoId, true);
				//var results = await _repo.GetEventoAsyncById(EventoId, true);

				var results = _mapper.Map<EventoModel>(evento);

				return Ok(results);
			}
			catch (System.Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
			}
		}

		[HttpGet("getByTema/{tema}")]
		public async Task<IActionResult> Get(string tema)
		{
			try
			{
				var eventos = await _repo.GetAllEventoAsyncByTema(tema, true);

				var results = _mapper.Map<EventoModel[]>(eventos);

				return Ok(results);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou - Erro: {ex.Message}");
			}
		}

		[HttpPost]
		public async Task<IActionResult> Post(EventoModel model)
		{
			//ToDo: sem a anotação no inicio da api apicontroller tenho que avisar para o metodo que o 
			//envio dos dados é via corpo com o frombody e preciso validar o model
			//if (!ModelState.IsValid)
			//	return this.StatusCode(StatusCodes.Status400BadRequest, ModelState);

			try
			{
				var evento = _mapper.Map<Evento>(model);

				_repo.Add(evento);

				if (await _repo.SaveChangesAsync())
				{
					return Created($"/api/evento/{model.Id}", _mapper.Map<EventoModel>(evento));
				}
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
			}

			return BadRequest();
		}

		[HttpPut("{EventoId}")]
		public async Task<IActionResult> Put(int EventoId, EventoModel model)
		{
			try
			{
				//if (!ModelState.IsValid) return BadRequest();

				var evento = await _repo.GetEventoAsyncById(EventoId, false);
				if (evento == null) return NotFound();

				//var idLotes = new List<int>();
				//var idRedesSociais = new List<int>();

				//model.Lotes.ForEach(item => idLotes.Add(item.Id));
				//model.RedesSociais.ForEach(item => idRedesSociais.Add(item.Id));

				//var lotes = evento.Lotes.Where(
				//    lote => !idLotes.Contains(lote.Id)
				//).ToArray();

				//var redesSociais = evento.RedesSociais.Where(
				//    rede => !idLotes.Contains(rede.Id)
				//).ToArray();

				//if (lotes.Length > 0) _repo.DeleteRange(lotes);
				//if (redesSociais.Length > 0) _repo.DeleteRange(redesSociais);

				_mapper.Map(model, evento);

				//ToDo: retirar depois que arrumar o mapeamento
				//MapModelToEntity(model, evento);

				_repo.Update(evento);

				if (await _repo.SaveChangesAsync())
				{
					//return Created($"/api/evento/{model.Id}", model);
					return Created($"/api/evento/{model.Id}", _mapper.Map<EventoModel>(evento));
				}
			}
			catch (System.Exception ex)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou " + ex.Message);
			}

			return BadRequest();
		}

		private void MapModelToEntity(EventoModel model, Evento evento)
		{
			evento.Nome = model.Nome;
			evento.Local = model.Local;
			evento.ImagemURL = model.ImagemURL;
			evento.DataEvento = Convert.ToDateTime(model.DataEvento);
			evento.Email = model.Email;
			evento.Telefone = model.Telefone;
			evento.QtdPessoas = model.QtdPessoas;
		}

		[HttpDelete("{EventoId}")]
		public async Task<IActionResult> Delete(int EventoId)
		{
			try
			{
				var evento = await _repo.GetEventoAsyncById(EventoId, false);
				if (evento == null) return NotFound();

				_repo.Delete(evento);

				if (await _repo.SaveChangesAsync())
				{
					return Ok();
				}
			}
			catch (System.Exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
			}

			return BadRequest();
		}
	}
}
