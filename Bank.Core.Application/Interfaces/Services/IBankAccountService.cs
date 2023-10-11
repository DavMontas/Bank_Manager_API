using Bank.Core.Application.Dto;
using Bank.Core.Application.Request;
using Bank.Core.Domain.Entities;

namespace Bank.Core.Application.Interfaces.Services
{
    public interface IBankAccountService : IGenericService<CreateBankAccountRequest, UpdateBankAccountRequest, BankAccountDto, BankAccount>
    {
        new Task<BankAccountDto> AddAsync(CreateBankAccountRequest request);
        Task<BankAccountDto> Transaccion(CreateTransactionRequest request);
        Task<BankAccountDto> GetByAccountNumberAsync(string accountNumber);
        Task DeleteAsync(string accountNumber);
    }
}
