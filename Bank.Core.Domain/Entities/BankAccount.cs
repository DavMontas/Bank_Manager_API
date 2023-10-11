using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Domain.Entities
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string AccountNumber  { get; set; } = default!;
        public double Amount { get; set; }

        //public int UserId { get; set; }
        //public User User { get; set; }

    }
}
