﻿using AutoMapper;
using Bank.Core.Application.Dto;
using Bank.Core.Application.Helpers;
using Bank.Core.Application.Interfaces.Repositories;
using Bank.Core.Application.Interfaces.Services;
using Bank.Core.Application.Request;
using Bank.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Application.Services
{
    public class BankAccountService : GenericService<CreateBankAccountRequest, UpdateBankAccountRequest, BankAccountDto, BankAccount>, IBankAccountService
    {
        private readonly IBankAccountRepository _repo;

        private readonly IMapper _mapper;
        private readonly AccountNumberGenerator _numberGenerator = new();
        public BankAccountService(IBankAccountRepository repo, IMapper mapper) : base(repo, mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async override Task<BankAccountDto> AddAsync(CreateBankAccountRequest request)
        {
            string accountNumber = _numberGenerator.NumberGenerator();
            if (await ExistAccount(accountNumber))
            {
                accountNumber = _numberGenerator.NumberGenerator();
            }
            request.AccountNumber = accountNumber;
            BankAccount entity = new()
            {
                AccountNumber = accountNumber,
                Amount = request.Amount,
            };

            entity = await _repo.AddAsync(entity);
            return _mapper.Map<BankAccountDto>(entity);
            
        }

        public async Task DeleteAsync(string accountNumber)
        {
            BankAccount e = await _repo.GetByAccountNumberAsync(accountNumber);
            await _repo.DeleteAsync(e);
        }

        public async Task<BankAccountDto> GetByAccountNumberAsync(string accountNumber)
        {
            BankAccount bankAccount = await _repo.GetByAccountNumberAsync(accountNumber);
            return _mapper.Map<BankAccountDto>(bankAccount);
        }

        public async Task<BankAccountDto> Transaccion(CreateTransactionRequest request)
        {
            var listAccounts = await base.GetAllAsync();
     
            var _accountFrom =  listAccounts.FirstOrDefault(e => e.AccountNumber == request.AccountFrom);
            var _accountTo = listAccounts.FirstOrDefault(e => e.AccountNumber == request.AccountTo);

            var transactionValue = request.Amount;
            if (_accountFrom != null && _accountTo != null)
            {
                _accountFrom.Amount = _accountFrom.Amount - transactionValue;
                _accountTo.Amount = _accountTo.Amount + transactionValue;
            }
            BankAccount bankAccountFrom = _mapper.Map< BankAccount>(_accountFrom);
            BankAccount bankAccountTo = _mapper.Map<BankAccount>(_accountTo);
            await _repo.UpdateAsync(bankAccountFrom, _accountFrom!.Id);
            await _repo.UpdateAsync(bankAccountTo, _accountTo!.Id);

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
