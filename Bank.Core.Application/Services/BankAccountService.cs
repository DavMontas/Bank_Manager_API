using AutoMapper;
using Bank.Core.Application.Dto;
using Bank.Core.Application.Helpers;
using Bank.Core.Application.Interfaces.Repositories;
using Bank.Core.Application.Interfaces.Services;
using Bank.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Application.Services
{
    public class BankAccountService : GenericService<BankAccountDto, BankAccount>, IBankAccountService
    {
        private readonly IBankAccountRepository _repo;

        private readonly IMapper _mapper;
        private readonly AccountNumberGenerator _numberGenerator = new();
        public BankAccountService(IBankAccountRepository repo, IMapper mapper) : base(repo, mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async override Task<BankAccountDto> AddAsync(BankAccountDto dto)
        {
            string accountNumber = _numberGenerator.NumberGenerator();
            if (await ExistAccount(accountNumber))
            {
                accountNumber = _numberGenerator.NumberGenerator();
            }
            dto.AccountNumber = accountNumber;
            BankAccount entity = new();
            entity.AccountNumber = accountNumber;
            entity.Amount = dto.Amount;
            entity = await _repo.AddAsync(entity);
            return _mapper.Map<BankAccountDto>(entity);
            
        }

        public async Task<BankAccountDto> Transaccion(string AccountFrom, string AccountTo, double Amount)
        {
            var listAccounts = await base.GetAllAsync();
     
            var _accountFrom =  listAccounts.FirstOrDefault(e => e.AccountNumber == AccountFrom);
            var _accountTo = listAccounts.FirstOrDefault(e => e.AccountNumber == AccountTo);


            if (_accountFrom != null && _accountTo != null)
            {
                _accountFrom.Amount = _accountFrom.Amount - Amount;
                _accountTo.Amount = _accountTo.Amount + Amount;
            }
            BankAccount bankAccountFrom = _mapper.Map< BankAccount>(_accountFrom);
            BankAccount bankAccountTo = _mapper.Map<BankAccount>(_accountTo);
            await _repo.UpdateAsync(bankAccountFrom, _accountFrom.Id);
            await _repo.UpdateAsync(bankAccountTo, _accountTo.Id);


            await _repo.SaveChanges();

            return _mapper.Map<BankAccountDto>(_accountTo);
        }



       
        private async Task<bool> ExistAccount(string accountNumber)
        {
            var listBankAccouts = await _repo.GetAllAsync();
            if(listBankAccouts.Count() != 0 )
            {
                return false;
            }
            var accounts = listBankAccouts.Where(e => e.AccountNumber == accountNumber);
            if (accounts.Count() == 0)
            {
                return false;
            }
            return true;


        }
    }
}
