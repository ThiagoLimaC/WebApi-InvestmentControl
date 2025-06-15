using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

    }
}
