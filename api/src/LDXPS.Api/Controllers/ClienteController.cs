using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using LDXPS.Domain.Entidades;
using LDXPS.Domain.Paginations;
using LDXPS.Domain.Repositorios;
using LDXPS.Domain.Servicos;
using LDXPS.Domain.Exceptions;

namespace LDXPS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ApiController
    {
        private readonly IControleTransacao _controleTranscao;
        private readonly IServicoCliente _servicoCliente;
        private readonly ILogger<ClienteController> _logger;
        public ClienteController(IControleTransacao controleTranscao, IServicoCliente servicoCliente, ILogger<ClienteController> logger)
        {
            _controleTranscao = controleTranscao;
            _servicoCliente = servicoCliente;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                return Ok(await _servicoCliente.ObterTodos());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex);
            }
        }

        [HttpGet("paginacao")]
        public async Task<ActionResult<Pagination<Cliente>>> ObterTodosComPaginacao([FromQuery] Pagination<Cliente> pagination)
        {
            try
            {
                return await _servicoCliente.ObterTodos(pagination);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("{codigo}")]
        public async Task<ActionResult<Cliente>> Obter(string codigo)
        {
            try
            {
                if (string.IsNullOrEmpty(codigo)) return NoContent();
                var cliente = await _servicoCliente.Obter(Guid.Parse(codigo));
                if (cliente == null) NotFound();
                return cliente;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Cliente cliente)
        {
            try
            {
                if (!ModelState.IsValid) return CustomResponse(ModelState);
                var validationResult = await _servicoCliente.Adicionar(cliente);
                if (!validationResult.IsValid) return CustomResponse(validationResult);
                await _controleTranscao.Salvar();
                return Created(cliente.Codigo.ToString(), cliente);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex);
            }
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> Atualizar(Guid codigo,
                [FromBody] Cliente cliente)
        {
            try
            {
                if (codigo != cliente.Codigo) return BadRequest();
                if (!cliente.EhValido()) return CustomResponse(cliente);

                var validationResult = await _servicoCliente.Atualizar(cliente);
                if (!validationResult.IsValid) return CustomResponse(validationResult);
                await _controleTranscao.Salvar();
                return NoContent();
            }
            catch (EntidadeNaoEncontradaException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex);
            }
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Deletar(Guid codigo)
        {
            try
            {
                if (codigo == Guid.Empty) return NotFound();
                await _servicoCliente.Deletar(codigo);
                await _controleTranscao.Salvar();
                return NoContent();
            }
            catch (EntidadeNaoEncontradaException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex);
            }
        }
    }
}
