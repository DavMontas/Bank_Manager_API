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
    public class UserService : GenericService<UserDto, User>, IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        public UserService(IUserRepository repo, IMapper mapper) : base(repo, mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}
