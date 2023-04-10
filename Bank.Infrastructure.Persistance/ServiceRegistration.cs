using Bank.Core.Application.Interfaces.Repositories;
using Bank.Infrastructure.Persistance.Context;
using Bank.Infrastructure.Persistance.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infrastructure.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceInfrastructure(this IServiceCollection svc, IConfiguration config)
        {
            svc.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(config.GetConnectionString("DefaultConnection"),
                    m => m.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            #region 'repos'

            svc.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            svc.AddTransient<IBankAccountRepository, BankAccountRepository>();
            svc.AddTransient<IUserRepository, UserRepository>();

            #endregion
        }
    }
}