using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Application.Dto
{
    public class TransactionDto
    {
        public string AccountFrom { get; set; }
        public string AccountTo { get; set;}
        public double Amount { get; set; }


    }
}
