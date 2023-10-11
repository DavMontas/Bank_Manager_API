using AutoMapper;
using Bank.Core.Application.Dto;
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
    public class TransactionService : GenericService<CreateTransactionRequest, UpdateTransactionRequest, TransactionDto, Transaction>, ITransactionService
    {
        private readonly ITransactionRepository _repo;
        private readonly IMapper _mapper;
        public TransactionService(ITransactionRepository repo, IMapper mapper) : base(repo, mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}
