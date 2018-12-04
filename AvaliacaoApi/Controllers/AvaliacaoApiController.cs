using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using avaliacao.Controllers;
using AvaliacaoApi.Business.Interfaces;
using AvaliacaoApi.Data.Interfaces;
using AvaliacaoApi.Models;
using AvaliacaoApi.Models.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AvaliacaoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/")]
    public class AvaliacaoApiController : BaseController
    {
        private readonly ApiContext _context;
        private IJogoBusiness _business;

        private ISistemaBusiness _businessSistema;
    
        public AvaliacaoApiController(ApiContext context, IJogoBusiness business, ISistemaBusiness businessSistema)
        {
            _context = context;
            _business = business;
            _businessSistema = businessSistema;
        }

        [HttpPost, Route("Jogo")]
        public async Task<IActionResult> Post([FromBody]Jogo jogo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_business.ValidarJogo(jogo))
                return Conflict(_business.ErrosValidacao);
            try
            {
                jogo.DataHora = DateTime.Now;
                _businessSistema.AddJogo(jogo);
                return Ok(jogo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("Jogos")]
        public async Task<IActionResult> GetTodos()
        {
            return Ok(_businessSistema.GetTodos());
        }

        [HttpGet("GerarSorteio")]
        public async Task<IActionResult> GetSorteio()
        {
            var retorno = _businessSistema.GetSorteio();
            return Ok(retorno.Numeros);
        }

        [HttpGet("GetNumerosOpcoes/{tipoSorteio}")]
        public async Task<IActionResult> GetNumerosOpcoes([FromRoute] int tipoSorteio)
        {
            return Ok(_business.BuscarNumerosOpcoesPorTipoSorteio(tipoSorteio));
        }

        [HttpGet("GetPremiados")]
        public async Task<IActionResult> GetPremiados()
        {
            var retorno = _businessSistema.GetPremiados();
            return Ok(retorno);
        }
    }
}
