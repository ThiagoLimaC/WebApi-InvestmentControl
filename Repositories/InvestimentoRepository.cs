using Microsoft.EntityFrameworkCore;
using WebApi_InvestmentControl.Data;
using WebApi_InvestmentControl.Models;
using WebApi_InvestmentControl.Repositories.Interfaces;

namespace WebApi_InvestmentControl.Repositories
{
    public class InvestimentoRepository : IInvestimentoRepository
    {

        private readonly AppDbContext _dbContext;

        public InvestimentoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(InvestimentoModel investimento)
        {
            await _dbContext.Investimentos.AddAsync(investimento);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteASync(int id)
        {
            InvestimentoModel investimento = await _dbContext.Investimentos.FindAsync(id);
            _dbContext.Investimentos.Remove(investimento);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<InvestimentoModel>> GetAllAsync()
        {
            var investimentos = await _dbContext.Investimentos.ToListAsync();
            return investimentos;
        }

        public async Task<InvestimentoModel> GetByIdAsync(int id)
        {
            var investimento = await _dbContext.Investimentos.FindAsync(id);
            return investimento;
        }

        public async Task UpdateAsync(InvestimentoModel investimentoEditado)
        {
            var investimento = await _dbContext.Investimentos.FindAsync(investimentoEditado.Id);

            investimento.Nome = investimentoEditado.Nome;
            investimento.Tipo = investimentoEditado.Tipo;
            investimento.Valor = investimentoEditado.Valor;
            investimento.DataInvestimento = investimentoEditado.DataInvestimento;

            _dbContext.Investimentos.Update(investimento);
            await _dbContext.SaveChangesAsync();
        }
    }
}
