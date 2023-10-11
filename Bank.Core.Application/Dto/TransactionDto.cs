using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Application.Dto
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public string AccountFrom { get; set; } = default!;
        public string AccountTo { get; set; } = default!;
        public double Amount { get; set; }
    }
}
