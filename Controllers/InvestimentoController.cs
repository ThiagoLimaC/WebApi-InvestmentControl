using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_InvestmentControl.Dtos;
using WebApi_InvestmentControl.Models;
using WebApi_InvestmentControl.Services;

namespace WebApi_InvestmentControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestimentoController : ControllerBase
    {

        private readonly InvestimentoService _investimentoService;

        public InvestimentoController(InvestimentoService investimentoService)
        {
            _investimentoService = investimentoService;
        }

        [HttpGet("ListarInvestimentos")]
        public async Task<ActionResult<ResponseModel<List<InvestimentoModel>>>> ListarInvestimentos()
        {
            var investimentos = await _investimentoService.ListarInvestimentos();
            return Ok(investimentos);
        }

        [HttpGet("BuscarInvestimentoPorId")]
        public async Task<ActionResult<ResponseModel<List<InvestimentoModel>>>> BuscarInvestimentoPorId(int id)
        {
            var investimentos = await _investimentoService.BuscarInvestimentoPorId(id);
            return Ok(investimentos);
        }

        [HttpPost("CriarInvestimento")]
        public async Task<ActionResult<ResponseModel<List<InvestimentoModel>>>> CriarInvestimento(InvestimentoCriacaoDto investimentoCriacaoDto)
        {
            var investimentos = await _investimentoService.CriarInvestimento(investimentoCriacaoDto);
            return Ok(investimentos);
        }

        [HttpPut("EditarInvestimento")]
        public async Task<ActionResult<ResponseModel<List<InvestimentoModel>>>> EditarInvestimento(InvestimentoEdicaoDto investimentoEdicaoDto)
        {
            var investimentos = await _investimentoService.EditarInvestimento(investimentoEdicaoDto);
            return Ok(investimentos);
        }

        [HttpDelete("ExcluirInvestimento")]
        public async Task<ActionResult<ResponseModel<List<InvestimentoModel>>>> ExcluirInvestimento(int id)
        {
            var investimentos = await _investimentoService.ExcluirInvestimento(id);
            return Ok(investimentos);
        }
    }
}
