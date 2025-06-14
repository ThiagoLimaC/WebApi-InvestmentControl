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

        public Task<ResponseModel<List<InvestimentoModel>>> AddAsync(InvestimentoModel investimento)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<InvestimentoModel>>> DeleteASync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<InvestimentoModel>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<InvestimentoModel>>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<InvestimentoModel>>> UpdateAsync(InvestimentoModel investimento)
        {
            throw new NotImplementedException();
        }
    }
}
