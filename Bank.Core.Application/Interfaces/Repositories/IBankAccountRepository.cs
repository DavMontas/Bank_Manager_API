using Bank.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Application.Interfaces.Repositories
{
    public interface IBankAccountRepository : IGenericRepository<BankAccount>
    {
    }
}
