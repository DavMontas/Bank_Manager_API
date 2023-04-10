using Bank.Core.Application.Interfaces.Repositories;
using Bank.Core.Domain.Entities;
using Bank.Infrastructure.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infrastructure.Persistance.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext _db;
        public UserRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
