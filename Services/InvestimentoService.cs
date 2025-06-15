using WebApi_InvestmentControl.Dtos;
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

        public async Task<ResponseModel<InvestimentoModel>> BuscarInvestimentoPorId(int id)
        {
            ResponseModel<InvestimentoModel> resposta = new ResponseModel<InvestimentoModel>();

            try
            {
                var investimento = await _investimentoRepository.GetByIdAsync(id);

                if (investimento == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = investimento;
                resposta.Mensagem = "Investimento localizado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
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

        public async Task<ResponseModel<List<InvestimentoModel>>> CriarInvestimento (InvestimentoCriacaoDto investimentoCriacaoDto)
        {
            ResponseModel<List<InvestimentoModel>> resposta = new ResponseModel<List<InvestimentoModel>>();

            try
            {
                var investimento = new InvestimentoModel()
                {
                    Nome = investimentoCriacaoDto.Nome,
                    Tipo = investimentoCriacaoDto.Tipo,
                    Valor = investimentoCriacaoDto.Valor,
                    DataInvestimento = investimentoCriacaoDto.DataInvestimento
                };

                await _investimentoRepository.AddAsync(investimento);

                resposta.Dados = await _investimentoRepository.GetAllAsync();
                resposta.Mensagem = "Investimento cadastrado com sucesso!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<InvestimentoModel>>> EditarInvestimento(InvestimentoEdicaoDto investimentoEdicaoDto)
        {
            ResponseModel<List<InvestimentoModel>> resposta = new ResponseModel<List<InvestimentoModel>>();

            try
            {
                var investimento = await _investimentoRepository.GetByIdAsync(investimentoEdicaoDto.Id);

                if (investimento == null)
                {
                    resposta.Mensagem = "Investimento não localizado!";
                    return resposta;
                }

                investimento.Nome = investimentoEdicaoDto.Nome;
                investimento.Tipo = investimentoEdicaoDto.Tipo;
                investimento.Valor = investimentoEdicaoDto.Valor;
                investimento.DataInvestimento = investimentoEdicaoDto.DataInvestimento;

                await _investimentoRepository.UpdateAsync(investimento);

                resposta.Dados = await _investimentoRepository.GetAllAsync();
                resposta.Mensagem = "Investimento excluído com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<InvestimentoModel>>> ExcluirInvestimento(int id)
        {
            ResponseModel<List<InvestimentoModel>> resposta = new ResponseModel<List<InvestimentoModel>>();

            try
            {
                var investimento = await _investimentoRepository.GetByIdAsync(id);

                if (investimento == null)
                {
                    resposta.Mensagem = "Investimento não localizado!";
                    return resposta;
                }

                await _investimentoRepository.DeleteAsync(investimento);

                resposta.Dados = await _investimentoRepository.GetAllAsync();
                resposta.Mensagem = "Investimento editado com sucesso!";
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
