﻿using System;
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
        public string AccountNumber  { get; set; }
        public double Amount { get; set; }

    }
}
