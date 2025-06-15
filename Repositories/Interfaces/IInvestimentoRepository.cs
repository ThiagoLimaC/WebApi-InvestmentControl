using WebApi_InvestmentControl.Models;

namespace WebApi_InvestmentControl.Repositories.Interfaces
{
    public interface IInvestimentoRepository
    {
        Task<InvestimentoModel> GetByIdAsync(int id);
        Task<List<InvestimentoModel>> GetAllAsync();
        Task AddAsync(InvestimentoModel investimento);
        Task UpdateAsync(InvestimentoModel investimento);
        Task DeleteAsync(InvestimentoModel investimento);
    }
}
