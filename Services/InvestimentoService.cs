using WebApi_InvestmentControl.Models;
using WebApi_InvestmentControl.Repositories.Interfaces;

namespace WebApi_InvestmentControl.Services
{
    public class InvestimentoService
    {
        private readonly IInvestimentoRepository _investimentoRepository;

        public InvestimentoService(IInvestimentoRepository investimentoRepository)
        {
            _investimentoRepository = investimentoRepository;
        }

       public async Task<ResponseModel<List<InvestimentoModel>>> ListarInvestimentos() 
       {
             ResponseModel<List<InvestimentoModel>> resposta = new ResponseModel<List<InvestimentoModel>>();

            try
            {
                var investimentos = await _investimentoRepository.GetAllAsync();

                resposta.Dados = investimentos;
                resposta.Mensagem = "Todos os investimentos foram coletados";

                return resposta;
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
       }
    }
}
