using WebApi_InvestmentControl.Models;

namespace WebApi_InvestmentControl.Repositories.Interfaces
{
    public interface IInvestimentoRepository
    {
        Task<ResponseModel<List<InvestimentoModel>>> GetByIdAsync(int id);
        Task<ResponseModel<List<InvestimentoModel>>> GetAllAsync();
        Task<ResponseModel<List<InvestimentoModel>>> AddAsync(InvestimentoModel investimento);
        Task<ResponseModel<List<InvestimentoModel>>> UpdateAsync(InvestimentoModel investimento);
        Task<ResponseModel<List<InvestimentoModel>>> DeleteASync(int id);
    }
}
