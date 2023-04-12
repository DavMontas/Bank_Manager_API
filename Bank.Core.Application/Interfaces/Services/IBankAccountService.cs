using Bank.Core.Application.Dto;
using Bank.Core.Domain.Entities;

namespace Bank.Core.Application.Interfaces.Services
{
    public interface IBankAccountService : IGenericService<BankAccountDto, BankAccount>
    {
        Task<BankAccountDto> AddAsync(BankAccountDto dto);
        Task<BankAccountDto> Transaccion(string AccountFrom, string AccountTo, double amount);
        Task<BankAccountDto> GetByAccountNumberAsync(string accountNumber);
        Task DeleteAsync(string accountNumber);
    }
}
