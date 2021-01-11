using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LDXPS.Domain.Repositorios;
using LDXPS.Domain.Servicos;
using LDXPS.Domain.Entidades;
using LDXPS.Domain.Exceptions;
using LDXPS.Domain.Paginations;
using Microsoft.Extensions.Logging;

namespace LDXPS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendedorController : ApiController
    {
        private readonly IControleTransacao _controleTranscao;
        private readonly IServicoVendedor _servicoVendedor;
        private readonly ILogger<VendedorController> _logger;
        public VendedorController(IControleTransacao controleTranscao, IServicoVendedor servicoVendedor, ILogger<VendedorController> logger)
        {
            _controleTranscao = controleTranscao;
            _servicoVendedor = servicoVendedor;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                return Ok(await _servicoVendedor.ObterTodos());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex);
            }
        }
        [HttpGet("paginacao")]
        public async Task<ActionResult<Pagination<Vendedor>>> ObterTodosComPaginacao([FromQuery] Pagination<Vendedor> pagination)
        {
            try
            {
                return await _servicoVendedor.ObterTodos(pagination);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("{codigo}")]
        public async Task<ActionResult<Vendedor>> Obter(string codigo)
        {
            try
            {
                if (string.IsNullOrEmpty(codigo)) return NotFound();
                var vendedor = await _servicoVendedor.Obter(Guid.Parse(codigo));
                if (vendedor == null) NotFound();
                return Ok(vendedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Vendedor vendedor)
        {
            try
            {
                if (!ModelState.IsValid) return CustomResponse(ModelState);
                var validationResult = await _servicoVendedor.Adicionar(vendedor);
                if (!validationResult.IsValid) return CustomResponse(validationResult);
                await _controleTranscao.Salvar();
                return Created(vendedor.Codigo.ToString(), vendedor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex);
            }
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> Atualizar(Guid codigo,
                [FromBody] Vendedor vendedor)
        {
            try
            {
                if (codigo != vendedor.Codigo) return BadRequest();
                if (!vendedor.EhValido()) return CustomResponse(vendedor);

                var validationResult = await _servicoVendedor.Atualizar(vendedor);
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
                await _servicoVendedor.Deletar(codigo);
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
