using Bank.Core.Application.Interfaces.Repositories;
using Bank.Core.Application.Interfaces.Services;
using Bank.Core.Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());


            service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            #region services

            service.AddTransient<IBankAccountService, BankAccountService>();
            service.AddTransient<ITransactionService, TransactionService>();

            #endregion
        }
    }
}
