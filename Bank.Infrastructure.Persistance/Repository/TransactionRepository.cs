using Bank.Core.Application.Interfaces.Repositories;
using Bank.Core.Domain.Entities;
using Bank.Infrastructure.Persistance.Context;

namespace Bank.Infrastructure.Persistance.Repository
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        private readonly AppDbContext _db;
        public TransactionRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
