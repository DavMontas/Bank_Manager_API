using AutoMapper;
using Bank.Core.Application.Dto;
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
        public BankAccountService(IBankAccountRepository repo, IMapper mapper) : base(repo, mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}
